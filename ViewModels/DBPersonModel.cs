using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics__Assignment.ViewModels
{
    public class DBPersonModel
    {
        [Key]
        [MaxLength(10, ErrorMessage ="Invalid SSN.")]
        public string SSN { get; set; }

        [Required]
        [Column("First name")]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [Column("Last name")]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [Column("Phonenumber")]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        [Column("City")]
        public CityModel City { get; set; }

        public List<PersonLanguageModel> PersonLanguages { get; set; }
    }
}
