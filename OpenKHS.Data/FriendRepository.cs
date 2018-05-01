using System;
using OpenKHS.Models;
using System.Collections.Generic;
using System.Linq;
using OpenKHS.Interfaces;

namespace OpenKHS.Data
{
    public class CongregationMemberRepository : ModelRepositoryBase, IModelRepository<CongregationMember>
    {
        public CongregationMemberRepository(DatabaseContext dbContext) : base(dbContext) { }

        public IList<CongregationMember> Index()
        {
            return DbContext.CongregationMembers.ToList();
        }

        public CongregationMember Show(int id)
        {
            return DbContext.CongregationMembers.Single(m => m.Id == id);
        }

        public void Store(CongregationMember @new)
        {
            ValidateStore(@new);
            DbContext.CongregationMembers.Add(@new);
        }

        public void Delete(CongregationMember model)
        {
            if (model != null)
            {
                DbContext.CongregationMembers.Remove(model);
            }
        }
    }
}
