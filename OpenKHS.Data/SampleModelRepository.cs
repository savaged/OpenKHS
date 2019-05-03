using OpenKHS.Interfaces;
using OpenKHS.Universal.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenKHS.Data
{
    public class SampleModelRepository 
        : ModelRepositoryBase, IModelRepository<SampleModel>
    {
        private readonly IList<SampleModel> _data;

        public SampleModelRepository(DatabaseContext dbContext) 
            : base(dbContext)
        {
            _data = new List<SampleModel>
            {
                new SampleModel
                {
                    Id = 70,
                    WeekStarting = new DateTime(2017, 05, 24),
                    Name = "Name F"
                },
                new SampleModel
                {
                    Id = 71,
                    WeekStarting = new DateTime(2017, 05, 24),
                    Name = "Name CC"
                },
                new SampleModel
                {
                    Id = 72,
                    WeekStarting = new DateTime(2017, 06, 03),
                    Name = "Name Z"
                },
                new SampleModel
                {
                    Id = 73,
                    WeekStarting = new DateTime(2017, 06, 05),
                    Name = "Name Y"
                },
                new SampleModel
                {
                    Id = 74,
                    WeekStarting = new DateTime(2017, 06, 07),
                    Name = "Name H"
                },
                new SampleModel
                {
                    Id = 75,
                    WeekStarting = new DateTime(2017, 06, 07),
                    Name = "Name F"
                },
                new SampleModel
                {
                    Id = 76,
                    WeekStarting = new DateTime(2017, 06, 11),
                    Name = "Name I"
                },
                new SampleModel
                {
                    Id = 77,
                    WeekStarting = new DateTime(2017, 06, 14),
                    Name = "Name BB"
                },
                new SampleModel
                {
                    Id = 78,
                    WeekStarting = new DateTime(2017, 06, 14),
                    Name = "Name A"
                },
                new SampleModel
                {
                    Id = 79,
                    WeekStarting = new DateTime(2017, 06, 18),
                    Name = "Name K"
                },
            };
        }

        public IList<SampleModel> Index()
        {
            return _data;
        }

        public SampleModel Show(int id)
        {
            return _data.Single(m => m.Id == id);
        }

        public void Store(SampleModel @new)
        {
            _data.Add(@new);
        }

        public void Delete(SampleModel model)
        {
            if (model != null)
            {
                _data.Remove(model);
            }
        }
    }
}
