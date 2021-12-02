using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics__Assignment.ViewModels
{
    public class CityModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public List<DBPersonModel> People { get; set; } 

        [Required]
        [Column("Country")]
        public int CountryModelId { get; set; }

        public CountryModel Country { get; set; }
    }
}
