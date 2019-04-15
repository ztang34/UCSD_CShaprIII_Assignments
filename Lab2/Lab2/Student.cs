using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab2
{
    public class Student : IDisposable
    {
        public string  FirstName { get; set; }
        public string LastName { get; set; }
        public DynamicArray<int> Scores { get; set; }

        public Student(string lastName, string firstName, int numScores)
        {
            LastName = lastName;
            FirstName = firstName;
            Scores = new DynamicArray<int>(numScores);
        }

       

        public override string ToString()
        {
            double total = 0;
            int count = 0;

            foreach(int score in Scores) //calculates average score
            {
                total += score;
                ++count;
            }

            if (count!=0)
            {
                return $"{LastName,-20}{FirstName,-10}{count,-5}{total / count:f3}";
            }
            else
            {
                throw new DivideByZeroException("Number of tests cannot be zero!");
            }
        }


        #region IDisposable Support
        private bool _Disposed = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_Disposed)
            {
                if (disposing)
                {
                    Scores?.Dispose();
                    Scores = null;
                }

                // no unmanaged object to free from memory

                _Disposed = true;
            }
        }


        ~Student()
        {
            Console.WriteLine($"Finalizing Student from thread " +
                $"{Thread.CurrentThread.ManagedThreadId}");
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Console.WriteLine($"Disposing Student from thread " +
               $"{Thread.CurrentThread.ManagedThreadId}");

            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
