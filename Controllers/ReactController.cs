using Microsoft.AspNetCore.Mvc;
using MVC_Basics__Assignment.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics__Assignment.Controllers
{
    public class ReactController : Controller
    {
        private readonly PeopleDatabaseContext _context;

        public ReactController(PeopleDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetPersonData()
        {
            var data = _context.People.OrderBy(a => a.FirstName).ToList();
            return new JsonResult ( data, new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}
