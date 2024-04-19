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
    public class ShopController : Controller
    {
        private readonly DatabaseContext _context;

        public ShopController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Shop
        public async Task<IActionResult> Index()
        {
            var shop = new Shop();

            shop.FeaturedGames = _context.Games.Where(m => m.isFeatured);
            shop.Games = _context.Games;

            return View(shop);
        }
        public async Task<IActionResult> AddCurrency()
        {
            return View();
        }

        public async Task<IActionResult> sys_currencyAdd(int? value, int? id)
        {
            var userUpdate = await _context.Users.FirstOrDefaultAsync(m => m.ID == id);

            try
            {
                if (userUpdate != null)
                {
                    userUpdate.funds += value ?? 5;
                }
                await _context.SaveChangesAsync();
                setSession(userUpdate);
                return Redirect("/Shop/Index");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
            }

            return View(userUpdate);
        }

        public async Task<IActionResult> sys_purchaseGame(int? id, int? gameID)
        {
            var userUpdate = await _context.Users.FirstOrDefaultAsync(m => m.ID == id);
            var gameGet = await _context.Games.FirstOrDefaultAsync(m => m.ID == gameID);

            try
            {
                if (userUpdate != null)
                {
                    _context.Libraries.Add(new Library() {gameID=gameGet.ID, userID=userUpdate.ID});
                }
                await _context.SaveChangesAsync();
                setSession(userUpdate);
                return RedirectToAction("Details", "Users", new { @id = id });
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
            }

            return View(userUpdate);
        }

        public void setSession(User user)
        {
            HttpContext.Session.SetInt32("user_ID", user.ID);
            HttpContext.Session.SetString("user_Name", user.Name);
            HttpContext.Session.SetInt32("user_Funds", user.funds);
        }

        // GET: Shop/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .FirstOrDefaultAsync(m => m.ID == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // GET: Shop/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shop/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Description,price")] Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }

        // GET: Shop/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        // POST: Shop/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Description,price")] Game game)
        {
            if (id != game.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.ID))
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
            return View(game);
        }

        // GET: Shop/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .FirstOrDefaultAsync(m => m.ID == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Shop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game != null)
            {
                _context.Games.Remove(game);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameExists(int id)
        {
            return _context.Games.Any(e => e.ID == id);
        }
    }
}
