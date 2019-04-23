using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib
{
    [SpecialClass(3)]
    public class Student 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<int> Scores { get; set; }

        public Student(string lastName, string firstName, int numScores)
        {
            LastName = lastName;
            FirstName = firstName;
            Scores = new List<int>(numScores);
        }



        public override string ToString()
        {
            double total = 0;
            int count = 0;

            foreach (int score in Scores) //calculates average score
            {
                total += score;
                ++count;
            }

            if (count != 0)
            {
                return $"{LastName,-20}{FirstName,-10}{count,-5}{total / count:f3}";
            }
            else
            {
                throw new DivideByZeroException("Number of tests cannot be zero!");
            }
        }
    }
}
