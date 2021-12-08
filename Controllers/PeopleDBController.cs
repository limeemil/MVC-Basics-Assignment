using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Basics__Assignment.Context;
using MVC_Basics__Assignment.Models;
using MVC_Basics__Assignment.ViewModels;

namespace MVC_Basics__Assignment.Controllers
{
    public class PeopleDBController : Controller
    {
        private readonly PeopleDatabaseContext _context;

        public PeopleDBController(PeopleDatabaseContext context)
        {
            _context = context;
        }

        // GET: PeopleDB
        public async Task<IActionResult> Index()
        {
            return View(await _context.People.ToListAsync());
        }

        // GET: PeopleDB/Details/5
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var query = from Person in _context.People
                        where Person.SSN == id
                        select Person;
            var people = query.ToList();
            var person = people.FirstOrDefault(m => m.SSN == id);
            /*var person = await _context.People
                .FirstOrDefaultAsync(m => m.ID == id);*/
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: PeopleDB/Create
        [Authorize(Roles = "Admin,User")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: PeopleDB/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,PhoneNumber,City")] DBPersonModel person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // GET: PeopleDB/Edit/5
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        // POST: PeopleDB/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Edit(string id, [Bind("ID,FirstName,LastName,PhoneNumber,City")] DBPersonModel person)
        {
            if (id != person.SSN)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.SSN))
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
            return View(person);
        }

        // GET: PeopleDB/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.People
                .FirstOrDefaultAsync(m => m.SSN == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: PeopleDB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var person = await _context.People.FindAsync(id);
            _context.People.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool PersonExists(string id)
        {
            return _context.People.Any(e => e.SSN == id);
        }
    }
}
