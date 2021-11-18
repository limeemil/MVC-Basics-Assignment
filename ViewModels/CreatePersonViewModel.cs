using MVC_Basics__Assignment.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics__Assignment.ViewModels
{
    public class CreatePersonViewModel
    {
        [Display(Name = "First name")]
        [Required(ErrorMessage = "First name is required!")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Last name is required!")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Display(Name = "Phone number")]
        [Required(ErrorMessage = "Phone number is required!")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "City is required!")]
        [DataType(DataType.Text)]
        public string City { get; set; }

        public List<Person> people = new List<Person>();

        public string Search { get; set; }
    }
}
