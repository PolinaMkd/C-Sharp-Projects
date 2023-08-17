using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Code_First_Console_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new StudentDbContext())
            {
                // Create a new student
                var newStudent = new Student
                {
                    StudentId = 1,
                    FirstName = "John",
                    LastName = "Smith"
                };

                // Add the student to the context and save changes
                context.Students.Add(newStudent);
                context.SaveChanges();

                Console.WriteLine("Student added successfully!");
            }
        }
    }
}
