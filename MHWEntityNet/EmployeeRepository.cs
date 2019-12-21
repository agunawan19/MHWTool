using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MHWEntity;
using MHWEntity.Models;

namespace MHWEntity
{
    public class EmployeeRepository
    {
        public List<Department> GetDepartments()
        {
            const string connectionString =
                "server=.;database=MHWDb;Trusted_Connection=True;multipleactiveresultsets=True;application name=EntityFramework";
            MHWContext context = new MHWContext(connectionString);
            return context.Departments.ToList();
        }
    }
}
