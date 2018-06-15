using System;
using OpenKHS.Models;
using System.Collections.Generic;
using System.Linq;
using OpenKHS.Interfaces;

namespace OpenKHS.Data
{
    public class LocalCongregationMemberRepository : ModelRepositoryBase, IModelRepository<LocalCongregationMember>
    {
        public LocalCongregationMemberRepository(DatabaseContext dbContext) : base(dbContext) { }

        public IList<LocalCongregationMember> Index()
        {
            return DbContext.LocalCongregationMembers.ToList();
        }

        public LocalCongregationMember Show(int id)
        {
            return DbContext.LocalCongregationMembers.Single(m => m.Id == id);
        }

        public void Store(LocalCongregationMember @new)
        {
            ValidateStore(@new);
            DbContext.LocalCongregationMembers.Add(@new);
        }

        public void Delete(LocalCongregationMember model)
        {
            if (model != null)
            {
                DbContext.LocalCongregationMembers.Remove(model);
            }
        }
    }
}
