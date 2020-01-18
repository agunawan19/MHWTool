using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EarningTaxationWithVisitorPattern
{
    public class Employee : ISalary
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        //public List<ISalary> Salaries => new List<ISalary>();
        public List<ISalary> Salaries = new List<ISalary>();

        public void Accept(IVisitor visitor)
        {
            foreach (var salary in Salaries)
            {
                salary.Accept(visitor);
            }
        }
    }
}
