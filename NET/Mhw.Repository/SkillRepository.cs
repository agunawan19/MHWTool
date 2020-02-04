using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AG.Common.Interfaces;
using Mhw.DataAccess;
using Mhw.Domain.Entities;

namespace Mhw.Repository
{
    public class SkillRepository : GenericRepository<Skill>, ISkillRepository
    {
        public SkillRepository(IUnitOfWork<MhwContext> unitOfWork) : base(unitOfWork)
        {
        }

        public SkillRepository(MhwContext context) : base(context)
        {
        }

        public IEnumerable<Skill> GetDetailAll(bool trackChanges = true) => trackChanges
            ? Context.Skills.Include(e => e.SkillLevels).ToList()
            : Context.Skills.AsNoTracking().Include(e => e.SkillLevels).AsNoTracking().ToList();
    }
}