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
    public class CityModelsController : Controller
    {
        private readonly PeopleDatabaseContext _context;

        public CityModelsController(PeopleDatabaseContext context)
        {
            _context = context;
        }

        // GET: CityModels
        public async Task<IActionResult> Index()
        {
            var peopleDatabaseContext = _context.Cities.Include(c => c.Country);
            return View(await peopleDatabaseContext.ToListAsync());
        }

        // GET: CityModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cityModel = await _context.Cities
                .Include(c => c.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cityModel == null)
            {
                return NotFound();
            }

            return View(cityModel);
        }

        // GET: CityModels/Create
        public IActionResult Create()
        {
            ViewData["CountryModelId"] = new SelectList(_context.Countries, "Id", "Name");
            return View();
        }

        // POST: CityModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CountryModelId")] CityModel cityModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cityModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryModelId"] = new SelectList(_context.Countries, "Id", "Name", cityModel.CountryModelId);
            return View(cityModel);
        }

        // GET: CityModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cityModel = await _context.Cities.FindAsync(id);
            if (cityModel == null)
            {
                return NotFound();
            }
            ViewData["CountryModelId"] = new SelectList(_context.Countries, "Id", "Name", cityModel.CountryModelId);
            return View(cityModel);
        }

        // POST: CityModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CountryModelId")] CityModel cityModel)
        {
            if (id != cityModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cityModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityModelExists(cityModel.Id))
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
            ViewData["CountryModelId"] = new SelectList(_context.Countries, "Id", "Name", cityModel.CountryModelId);
            return View(cityModel);
        }

        // GET: CityModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cityModel = await _context.Cities
                .Include(c => c.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cityModel == null)
            {
                return NotFound();
            }

            return View(cityModel);
        }

        // POST: CityModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cityModel = await _context.Cities.FindAsync(id);
            _context.Cities.Remove(cityModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CityModelExists(int id)
        {
            return _context.Cities.Any(e => e.Id == id);
        }
    }
}
