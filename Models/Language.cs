using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics__Assignment.Models
{
    public class Language
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<DBPerson> People { get; set; }
    }
}
