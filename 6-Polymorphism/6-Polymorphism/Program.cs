using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_Polymorphism
{
    
    // Step 1: Create the IQuittable interface
    public interface IQuittable
    {
        void Quit();
    }

    // Step 2: Employee class inherits from IQuittable interface and implements the Quit() method.
    public class Employee : IQuittable
    {
        // Employee properties and methods can be defined here...

        public void Quit()
        {
            // Implementation of the Quit() method when an Employee quits the job.
            Console.WriteLine("Employee has quit the job.");
            Console.ReadLine();
        }
    }

    public class Program
    {
        public static void Main()
        {
            // Step 3: Use polymorphism to create an object of type IQuittable and call the Quit() method on it.
            IQuittable quittableEmployee = new Employee();
            quittableEmployee.Quit();
        }
    }
        
    
}
