using System;

namespace Mhw.Library.Models
{
    public interface IEmployee
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime DateOfBirth { get; set; }
        string Department { get; set; }
        string Address { get; set; }
        string FullName { get; set; }
    }
}
