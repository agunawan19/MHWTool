﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Mhw.DataAccess;
using Mhw.Library.Models;

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

        public IEnumerable<Skill> GetDetailAll()
        {
            return Context.Skills.Include(e => e.SkillLevels).ToList();
        }
    }
}