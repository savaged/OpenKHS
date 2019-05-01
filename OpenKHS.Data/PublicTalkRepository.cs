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
        private readonly IList<PublicTalk> _index;

        public PublicTalkRepository(DatabaseContext dbContext) 
            : base(dbContext)
        {
            _index = DbContext.PublicTalks
                .Include(p => p.LocalSpeaker).ToList();
        }

        public IList<PublicTalk> Index()
        {
            return _index;
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
