using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics__Assignment.ViewModels
{
    public class PersonLanguageModel
    {
        public string PersonSSN { get; set; }

        public DBPersonModel Person { get; set; }

        public int LanguageId { get; set; }

        public LanguageModel Language { get; set; }
    }
}
