using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Method_Class
{
    // Step 1: Create a class named MathOperations
    public class MathOperations
    {
        // Step 1: Create a void method named PerformOperation that takes two integers as parameters.
        public void PerformOperation(int num1, int num2)
        {
            // Step 1: Perform a simple math operation on the first integer (num1)
            int result = num1 * 2;

            // Step 1: Display the second integer (num2) to the screen.
            Console.WriteLine($"The value of num2 is: {num2}");
            Console.ReadLine();
        }
    }

    // Step 2: Create a Console App to test the MathOperations class
    public class Program
    {
        public static void Main()
        {
            // Step 2: Instantiate the MathOperations class
            MathOperations mathOperations = new MathOperations();

            // Step 3: Call the method in the class, passing in two numbers (5 and 10).
            mathOperations.PerformOperation(5, 10);

            // Step 4: Call the method in the class, specifying the parameters by name (num1: 7, num2: 15).
            mathOperations.PerformOperation(num1: 7, num2: 15);
        }
    }
}     
      

