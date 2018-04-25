using System;
using OpenKHS.Models;
using System.Collections.Generic;
using System.Linq;
using OpenKHS.Interfaces;

namespace OpenKHS.Data
{
    public class FriendRepository : ModelRepositoryBase, IModelRepository<Friend>
    {
        public FriendRepository(DatabaseContext dbContext) : base(dbContext) { }

        public IList<Friend> Index()
        {
            return DbContext.Friends.ToList();
        }

        public Friend Show(int id)
        {
            return DbContext.Friends.Single(m => m.Id == id);
        }

        public void Store(Friend @new)
        {
            ValidateStore(@new);
            DbContext.Friends.Add(@new);
        }

        public void Update(Friend existing)
        {
            DbContext.SaveChanges();
        }

        public void Delete(Friend model)
        {
            DbContext.Friends.Remove(model);
            DbContext.SaveChanges();
        }
    }
}
