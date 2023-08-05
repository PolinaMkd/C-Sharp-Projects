using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_Operators
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Overloading the equality operator to compare two Employee objects based on their Id property
        public static bool operator ==(Employee emp1, Employee emp2)
        {
            // If both objects are null, or their Ids are equal, return true; otherwise, return false.
            if (ReferenceEquals(emp1, emp2))
                return true;
            if (ReferenceEquals(emp1, null) || ReferenceEquals(emp2, null))
                return false;
            return emp1.Id == emp2.Id;
        }

        // Overloading the inequality operator by simply using the negation of the equality operator
        public static bool operator !=(Employee emp1, Employee emp2)
        {
            return !(emp1 == emp2);
        }

        // Overriding the Equals method to ensure consistency with the overloaded equality operator
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Employee))
                return false;
            return this == (Employee)obj;
        }

        // Overriding the GetHashCode method to ensure consistency with the Equals method
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}

