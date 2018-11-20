using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OpenKHS.Interfaces;
using OpenKHS.Models;

namespace OpenKHS.Data
{
    public class PublicTalkRepository 
        : ModelRepositoryBase, IModelRepository<PublicTalk>
    {
        public PublicTalkRepository(DatabaseContext dbContext) 
            : base(dbContext) { }

        public IList<PublicTalk> Index()
        {
            var data = DbContext.PublicTalks
                .Include(p => p.LocalSpeaker).ToList();
            return data;
        }

        public PublicTalk Show(int id)
        {
            return DbContext.PublicTalks.Single(m => m.Id == id);
        }

        public void Store(PublicTalk @new)
        {
            ValidateStore(@new);
            DbContext.PublicTalks.Add(@new);
        }

        public void Delete(PublicTalk model)
        {
            if (model != null)
            {
                DbContext.PublicTalks.Remove(model);
            }
        }
    }
}
