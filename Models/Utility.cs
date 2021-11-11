using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics__Assignment.Models
{
    public class Utility
    {
        //Checks if patient has a fever. Fever threshold is assumed to be 38 in this case.
        public static string HasFever(double temp)
        {
            if (temp >= 38)
            {
                return "You have a fever!";
            }
            else
            {
                return "You do not have a fever.";
            }
        }

        
    }
}
