using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameStore.Data;
using GameStore.Models;
using Microsoft.AspNetCore.Mvc.Routing;
using GameStore.ViewModels;

namespace GameStore.Controllers
{
    public class ChatsController : Controller
    {
        private readonly DatabaseContext _context;

        public ChatsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Chats
        public async Task<IActionResult> Index(int id)
        {
            var openChat = new openChatModel();
            openChat.userID = HttpContext.Session.GetInt32("user_ID") ?? -1;
            openChat.user = await _context.Users.FirstOrDefaultAsync(c => c.ID == openChat.userID);
            openChat.user2ID = id;
            openChat.user2 = await _context.Users.FirstOrDefaultAsync(c => c.ID == openChat.user2ID);

            openChat.chats = await _context.Chats
                .Where(c => c.user2Id == id && c.user1Id == HttpContext.Session.GetInt32("user_ID") || c.user2Id == HttpContext.Session.GetInt32("user_ID") && c.user1Id == id)
                .ToListAsync();

            return View(openChat);
        }

        // GET: Chats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chat = await _context.Chats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chat == null)
            {
                return NotFound();
            }

            return View(chat);
        }

        // GET: Chats/Create
        public IActionResult Create(int userID1, int userID2)
        {
            var chat = new Chat() { user1Id = userID1, user2Id = userID2};
            return View(chat);
        }

        // POST: Chats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("message", "user1Id", "user2Id")] Chat chat)
        {
            chat.dateTime = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Add(chat);
                await _context.SaveChangesAsync();
                return Redirect("/Chats/Index/" + chat.user2Id);
            }
            return View(chat);
        }

        // GET: Chats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chat = await _context.Chats.FindAsync(id);
            if (chat == null)
            {
                return NotFound();
            }
            return View(chat);
        }

        // POST: Chats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,user1Id,user2Id,dateTime,message")] Chat chat)
        {
            if (id != chat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChatExists(chat.Id))
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
            return View(chat);
        }

        // GET: Chats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chat = await _context.Chats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chat == null)
            {
                return NotFound();
            }

            return View(chat);
        }

        // POST: Chats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chat = await _context.Chats.FindAsync(id);
            if (chat != null)
            {
                _context.Chats.Remove(chat);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChatExists(int id)
        {
            return _context.Chats.Any(e => e.Id == id);
        }
    }
}
