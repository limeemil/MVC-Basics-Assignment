using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics__Assignment.Models
{
    public class Person
    {
        public int ID { get; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string City { get; set; }

        public static List<Person> people = new List<Person>();

        private static int _idCounter = 0;

        public Person()
        {

        }
        public Person(string firstName, string lastName, string phoneNumber, string city)
        {
            ID = _idCounter++;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            City = city;
        }

        public static void GeneratePeople()
        {
            people.AddRange(new List<Person> {
            new Person ("Andreas", "Andersson", "5555555555", "Borås"),
            new Person ("Göran", "Gunnarsson", "0123456789", "Göteborg"),
            new Person ("Robert", "Ström", "0987654321", "Stockholm"),
            });
        }
    }
}
