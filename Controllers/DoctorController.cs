using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics__Assignment.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult FeverCheck()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(float input)
        {
            
            double temp;
            bool success = double.TryParse(Request.Form["temperature"].ToString().Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out temp);
            if (success)
            {
                ViewBag.message = Models.Utility.HasFever(temp);
            }
            
            else
            {
                ViewBag.message = "Please enter a number.";
            }
            
            return View("FeverCheck");
        }
    }
}
