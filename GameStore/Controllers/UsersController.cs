﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameStore.Data;
using GameStore.Models;

namespace GameStore.Controllers
{
    public class UsersController : Controller
    {
        private readonly DatabaseContext _context;

        public UsersController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _context.Users
                    .Include(m => m.Library.Where(u => u.userID == id))
                        .ThenInclude(m => m.game)
                    .FirstOrDefaultAsync(m => m.ID == id);
            /*Essentially inner joins.*/

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        public async Task<IActionResult> sys_logoutUser()
        {
            HttpContext.Session.Remove("user_ID");
            HttpContext.Session.Remove("user_Funds");
            return Redirect("/Shop/Index");
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Password")] User user)
        {
            ModelState.Remove("profileAlreadyExisting");
            if (ModelState.IsValid)
            {
                var getUsers = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Name == user.Name);
                if (getUsers == null)
                {
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    setSession(user);
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("profileAlreadyExisting", "The Username is not availabel");
            }
            return View(user);
        }

        public void setSession(User user)
        {
            HttpContext.Session.SetInt32("user_ID", user.ID);
            HttpContext.Session.SetString("user_Name", user.Name);
            HttpContext.Session.SetInt32("user_Funds", user.funds);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public IActionResult Access()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Access([Bind("ID,Name,Password")] User user)
        {
            ModelState.Remove("loginfailed");
            var getUsers = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Name == user.Name && m.Password == user.Password);

            if (getUsers != null)
            {
                setSession(getUsers);
                return Redirect("/Shop/Index");
            }
            ModelState.AddModelError("loginfailed", "The Username or the Password you've entered are Invalid.");
            return View();
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Password")] User user)
        {
            if (id != user.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.ID == id);
        }
    }
}
