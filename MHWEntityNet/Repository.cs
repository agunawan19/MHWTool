using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MHWEntity;
using MHWEntity.Models;

namespace MHWEntity
{
    public class Repository
    {
        public List<Department> GetDepartments()
        {
            ApiContext context = new ApiContext();
            return context.Departments.ToList();
        }
    }
}
