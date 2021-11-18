using Microsoft.AspNetCore.Mvc;
using MVC_Basics__Assignment.Models;
using MVC_Basics__Assignment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics__Assignment.Controllers
{
    public class PeopleController : Controller
    {
        
        public IActionResult People()
        {
            CreatePersonViewModel vm = new CreatePersonViewModel();
            if (Person.people.Count < 1)
            {
                Person.GeneratePeople();
            }
            vm.people = Person.people;
            return View(vm);
        }

        /*public IActionResult People(CreatePersonViewModel viewModel)
        {
            viewModel.people.Clear();
            return View(viewModel);
        }*/

        public IActionResult Persons()
        {
            Person person = new Person();
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePerson(string firstName, string lastName, string phoneNumber, string city)
        {
            CreatePersonViewModel vm = new CreatePersonViewModel();
            if (ModelState.IsValid)
            {
                
                Person.people.Add(new Person (firstName, lastName, phoneNumber, city));
                vm.people = Person.people;
            }
            return View("People", vm);
        }

        
        public IActionResult Search(string searchString)
        {
            CreatePersonViewModel vm = new CreatePersonViewModel();
            foreach (var item in Person.people)
            {
                if (item.FirstName.Equals(searchString) || item.LastName.Equals(searchString) || item.City.Equals(searchString))
                {
                    vm.people.Add(item);
                }
            }
            return View("People", vm);
        }
        public IActionResult DeletePerson(int id)
        {
            CreatePersonViewModel vm = new CreatePersonViewModel();
            if (Person.people.Count > 0)
            {
                bool success = Person.people.Remove(Person.people.FirstOrDefault(x => x.ID == id));
            }
            
            vm.people = Person.people;
            return View("People", vm);
        }

        public PartialViewResult PersonList()
        {
            return PartialView("_PersonPartial");
        }
    }
}
