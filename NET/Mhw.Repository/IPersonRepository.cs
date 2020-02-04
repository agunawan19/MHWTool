using System.Collections.Generic;
using AG.Common.Interfaces;
using Mhw.Domain.Entities;

namespace Mhw.Repository
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        IEnumerable<Person> GetPersonByName(string name);
    }
}