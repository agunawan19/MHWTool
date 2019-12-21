using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHWEntity
{
    public class Configuration : DbConfiguration
    {
        public Configuration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new DefaultExecutionStrategy());
            const string conn = "Server =.;Database=MHW;Trusted_Connection=True;";
            SetDefaultConnectionFactory(new SqlConnectionFactory(conn));
        }
    }
}
