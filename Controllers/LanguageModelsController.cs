using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Basics__Assignment.Context;
using MVC_Basics__Assignment.ViewModels;

namespace MVC_Basics__Assignment.Controllers
{
    public class LanguageModelsController : Controller
    {
        private readonly PeopleDatabaseContext _context;

        public LanguageModelsController(PeopleDatabaseContext context)
        {
            _context = context;
        }

        // GET: LanguageModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Languages.ToListAsync());
        }

        // GET: LanguageModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var languageModel = await _context.Languages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (languageModel == null)
            {
                return NotFound();
            }

            return View(languageModel);
        }

        // GET: LanguageModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LanguageModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] LanguageModel languageModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(languageModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(languageModel);
        }

        // GET: LanguageModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var languageModel = await _context.Languages.FindAsync(id);
            if (languageModel == null)
            {
                return NotFound();
            }
            return View(languageModel);
        }

        // POST: LanguageModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] LanguageModel languageModel)
        {
            if (id != languageModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(languageModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LanguageModelExists(languageModel.Id))
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
            return View(languageModel);
        }

        // GET: LanguageModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var languageModel = await _context.Languages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (languageModel == null)
            {
                return NotFound();
            }

            return View(languageModel);
        }

        // POST: LanguageModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var languageModel = await _context.Languages.FindAsync(id);
            _context.Languages.Remove(languageModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LanguageModelExists(int id)
        {
            return _context.Languages.Any(e => e.Id == id);
        }
    }
}
