using System;
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
    public class CommunitiesController : Controller
    {
        private readonly DatabaseContext _context;

        public CommunitiesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Communities
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.Communities.Include(c => c.game).Include(c => c.user);
            return View(await databaseContext.ToListAsync());
        }

        // GET: Communities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var community = await _context.Communities
                .Include(c => c.game)
                .Include(c => c.user)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (community == null)
            {
                return NotFound();
            }

            return View(community);
        }

        // GET: Communities/Create
        public IActionResult Create()
        {
            ViewData["gameID"] = new SelectList(_context.Games, "ID", "ID");
            ViewData["userID"] = new SelectList(_context.Users, "ID", "ID");
            return View();
        }

        // POST: Communities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,userID,gameID,message")] Community community)
        {
            if (ModelState.IsValid)
            {
                _context.Add(community);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["gameID"] = new SelectList(_context.Games, "ID", "ID", community.gameID);
            ViewData["userID"] = new SelectList(_context.Users, "ID", "ID", community.userID);
            return View(community);
        }

        // GET: Communities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var community = await _context.Communities.FindAsync(id);
            if (community == null)
            {
                return NotFound();
            }
            ViewData["gameID"] = new SelectList(_context.Games, "ID", "ID", community.gameID);
            ViewData["userID"] = new SelectList(_context.Users, "ID", "ID", community.userID);
            return View(community);
        }

        // POST: Communities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,userID,gameID,message")] Community community)
        {
            if (id != community.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(community);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommunityExists(community.ID))
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
            ViewData["gameID"] = new SelectList(_context.Games, "ID", "ID", community.gameID);
            ViewData["userID"] = new SelectList(_context.Users, "ID", "ID", community.userID);
            return View(community);
        }

        // GET: Communities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var community = await _context.Communities
                .Include(c => c.game)
                .Include(c => c.user)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (community == null)
            {
                return NotFound();
            }

            return View(community);
        }

        // POST: Communities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var community = await _context.Communities.FindAsync(id);
            if (community != null)
            {
                _context.Communities.Remove(community);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommunityExists(int id)
        {
            return _context.Communities.Any(e => e.ID == id);
        }
    }
}
