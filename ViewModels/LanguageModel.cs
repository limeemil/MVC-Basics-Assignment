using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics__Assignment.ViewModels
{
    public class LanguageModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public List<PersonLanguageModel> PersonLanguages { get; set; }
    }
}
