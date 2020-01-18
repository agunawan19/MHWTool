using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoFactory.GangOfFour.Visitor.RealWorld.Domains
{
    public class Employees
    {
        private readonly List<Employee> _employees = new List<Employee>();

        public Employees Attach(Employee employee)
        {
            _employees.Add(employee);
            return this;
        }

        public Employees Detach(Employee employee)
        {
            _employees.Remove(employee);
            return this;
        }

        public Employees Accept(IVisitor visitor)
        {
            foreach (var e in _employees)
            {
                e.Accept(visitor);
            }

            Console.WriteLine();
            return this;
        }
    }
}
