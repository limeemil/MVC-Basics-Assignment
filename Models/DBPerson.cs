using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics__Assignment.Models
{
    public class DBPerson
    {
        
        public string SSN { get; set; }

        
        public string FirstName { get; set; }

        
        public string LastName { get; set; }

        
        public string PhoneNumber { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }
    }
}
