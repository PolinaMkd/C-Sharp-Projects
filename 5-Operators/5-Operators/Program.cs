using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_Operators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Instantiate two Employee objects and assign values to their properties
            Employee emp1 = new Employee { Id = 1, FirstName = "John", LastName = "Doe" };
            Employee emp2 = new Employee { Id = 2, FirstName = "Jane", LastName = "Smith" };

            // Compare the two Employee objects using the overloaded operators
            if (emp1 == emp2)
            {
                Console.WriteLine("The Employee objects are equal based on their Ids.");
            }
            else
            {
                Console.WriteLine("The Employee objects are not equal based on their Ids.");
            }
                     

            // Wait for user input before closing the console window
            Console.ReadLine();
        }
    }
}
