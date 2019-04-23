using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib
{
    [SpecialClass(1)]
    public class Person
    {
        public enum Genders
        {
            Unknown,
            Make,
            Female,
            Other
        };

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DOB { get; set; }
        public Genders Gender { get; set; }

        public Person()
        {
            LastName = "Unknown";
            FirstName = "Unknown";
            DOB = DateTime.MinValue;
            Gender = Genders.Unknown;
        }

        public Person(string lastName, string firstName, DateTime dob, Genders gender)
        {
            LastName = lastName;
            FirstName = firstName;
            DOB = dob;
            Gender = gender;
        }

        public override string ToString()
        {
            return $"{LastName,20}{FirstName,15}{DOB,10:MM-dd-YYYY}{Gender,5}";
        }
    }
}
