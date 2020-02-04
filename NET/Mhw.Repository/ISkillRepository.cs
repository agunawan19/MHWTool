using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AG.Common.Interfaces;
using Mhw.Domain.Entities;

namespace Mhw.Repository
{
    public interface ISkillRepository : IGenericRepository<Skill>
    {
        IEnumerable<Skill> GetDetailAll(bool trackChanges = true);

        //IEnumerable<Skill> GetDetailAllNoTracking();
    }
}