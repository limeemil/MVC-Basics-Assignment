using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics__Assignment.Models
{
    public class Person
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Column("First name")]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [Column("Last name")]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Column("Phonenumber")]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [MaxLength(20)]
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

        public static List<Person> Read()
        {
            return people;
        }

        public static Person Read(int id)
        {
            Person targetPerson = people.Find(p => p.ID == id);
            return targetPerson;
        }

        public static bool Delete(Person person)
        {
            bool status = people.Remove(person);
            return status;
        }
    }
}
