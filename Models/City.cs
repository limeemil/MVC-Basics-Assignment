using MVC_Basics__Assignment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics__Assignment.Models
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<DBPerson> People { get; set; }

        public int CountryModelId { get; set; }

        public Country Country { get; set; }
    }
}
