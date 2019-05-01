using OpenKHS.Data;
using OpenKHS.Interfaces;
using OpenKHS.Models;
using System;
using System.Collections.Generic;

namespace OpenKHS.ViewModels.Utils
{
    public class RepositoryLookup : IRepositoryLookup
    {
        public RepositoryLookup(DatabaseContext dbContext)
        {
            Repositories = new Dictionary<Type, object>
            {
                { typeof(LocalCongregationMember), new LocalCongregationMemberRepository(dbContext) },
                { typeof(PmSchedule), new PmScheduleRepository(dbContext) },
                { typeof(ClmmSchedule), new ClmmScheduleRepository(dbContext) },
                { typeof(PublicTalk), new PublicTalkRepository(dbContext) },
                { typeof(VisitingSpeaker), new VisitingSpeakerRepository(dbContext) },
                { typeof(Congregation), new NeighbouringCongregationRepository(dbContext) }
            };
        }

        public IDictionary<Type, object> Repositories { get; }

        public IModelRepository<T> GetRelatedRepository<T>() where T : IModel, new()
        {
            return (IModelRepository<T>)Repositories[typeof(T)];
        }
    }
}
