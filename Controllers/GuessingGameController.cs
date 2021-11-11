using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics__Assignment.Controllers
{
    public class GuessingGameController : Controller
    {
        private readonly Random randGen = new Random();
        [HttpGet]
        public IActionResult GuessingGame()
        {
            int rand = randGen.Next(1, 101);
            HttpContext.Session.SetInt32("Number", rand);
            return View("GuessingGame");
        }

        [HttpPost]
        public IActionResult GuessingGame(int guess)
        {
            int correctNumber = (int)HttpContext.Session.GetInt32("Number");
            if (guess == correctNumber)
            {
                ViewBag.Guess = guess + " is correct!";
                int rand = randGen.Next(1, 101);
                HttpContext.Session.SetInt32("Number", rand);
            }
            else if (guess > correctNumber)
            {
                ViewBag.Guess = guess + " is too high.";
            }
            else if (guess < correctNumber)
            {
                ViewBag.Guess = guess + " is too low.";
            }
            else
            {
                ViewBag.Guess = "Invalid input";
            }
            return View("GuessingGame");
        }
    }
}
