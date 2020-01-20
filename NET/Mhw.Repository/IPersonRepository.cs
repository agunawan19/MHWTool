using Mhw.Library;
using Mhw.Library.Models;
using System.Collections.Generic;

namespace Mhw.Repository
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        IEnumerable<Person> GetPersonByName(string name);
    }
}