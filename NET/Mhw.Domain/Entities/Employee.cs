using System;

namespace Mhw.Domain.Entities
{
    public class Employee : IEmployee
    {
        public static Employee CreateInstance()
        {
            return new Employee();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
        public string FullName { get; set; }

        public Employee NameOfEmployee(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            FullName = $"{firstName} {lastName}";
            return this;
        }

        public Employee Born(string dateOfBirth)
        {
            DateOfBirth = Convert.ToDateTime(dateOfBirth);
            return this;
        }

        public Employee WorkingOn(string department)
        {
            Department = department;
            return this;
        }

        public Employee StaysAt(string address)
        {
            Address = address;
            return this;
        }
    }
}