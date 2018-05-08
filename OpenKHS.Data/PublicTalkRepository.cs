﻿using System;
using OpenKHS.Models;
using System.Collections.Generic;
using System.Linq;
using OpenKHS.Interfaces;

namespace OpenKHS.Data
{
    public class PublicTalkRepository : ModelRepositoryBase, IModelRepository<PublicTalk>
    {
        public PublicTalkRepository(DatabaseContext dbContext) : base(dbContext) { }

        public IList<PublicTalk> Index()
        {
            return DbContext.PublicTalks.ToList();
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