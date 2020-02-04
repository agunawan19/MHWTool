using System.Collections.Generic;
using System.Linq;
using AG.Common.Interfaces;
using Mhw.DataAccess;
using Mhw.Domain.Entities;

namespace Mhw.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(IUnitOfWork<MhwContext> unitOfWork) : base(unitOfWork)
        {
        }

        public PersonRepository(MhwContext context) : base(context)
        {
        }

        public IEnumerable<Person> GetPersonByName(string name)
        {
            return Context.Persons.Where(p => p.Name.ToLower().Contains(name)).ToList();
        }
    }
}