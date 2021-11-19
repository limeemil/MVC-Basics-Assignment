using Microsoft.AspNetCore.Mvc;
using MVC_Basics__Assignment.Models;
using MVC_Basics__Assignment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics__Assignment.Controllers
{
    public class AjaxController : Controller
    {
        public IActionResult Index()
        {
            CreatePersonViewModel vm = new CreatePersonViewModel();
            if (Person.people.Count < 1)
            {
                Person.GeneratePeople();
            }
            vm.people = Person.people;
            return View(vm);
        }

        [HttpGet]
        public IActionResult GetPeople()
        {
            List<Person> people = Person.Read();
            return PartialView("_PeoplePartial", people);
        }

        [HttpPost]
        public IActionResult FindPersonById(int personID)
        {
            Person targetPerson = Person.Read(personID);
            List<Person> people = new List<Person>();
            if(targetPerson != null)
            {
                people.Add(targetPerson);
            }
            return PartialView("_PeoplePartial", people);
        }

        [HttpPost]
        public IActionResult DeletePersonById(int personID)
        {
            Person targetPerson = Person.Read(personID);
            List<Person> people = new List<Person>();
            bool success = false;
            if (targetPerson != null)
            {
                success = Person.Delete(targetPerson);
            }
            if (success)
            {
                return StatusCode(200);
            }
            
            return StatusCode(404);
        }
    }
}
