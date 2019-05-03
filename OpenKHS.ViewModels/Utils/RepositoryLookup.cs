using System;
using System.Collections.Generic;
using OpenKHS.Data;
using OpenKHS.Interfaces;
using OpenKHS.Models;

namespace OpenKHS.ViewModels.Utils
{
    public class RepositoryLookup
    {
        private static RepositoryLookup _default;

        public static RepositoryLookup Default =>
            _default ?? (_default = new RepositoryLookup());

        private RepositoryLookup()
        {
            var dbContext = DatabaseContext.GetDefault();

            Repositories = new Dictionary<Type, object>
            {
                { typeof(LocalCongregationMember), new LocalCongregationMemberRepository(dbContext) },
                { typeof(PmSchedule), new PmScheduleRepository(dbContext) },
                { typeof(ClmmSchedule), new ClmmScheduleRepository(dbContext) },
                { typeof(PublicTalk), new PublicTalkRepository(dbContext) },
                { typeof(VisitingSpeaker), new VisitingSpeakerRepository(dbContext) },
                { typeof(Congregation), new NeighbouringCongregationRepository(dbContext) },
                { typeof(SampleModel), new SampleModelRepository(dbContext) }
            };
        }

        public IDictionary<Type, object> Repositories { get; }

        public IModelRepository<T> GetRelatedRepository<T>() 
            where T : IModel, new()
        {
            return (IModelRepository<T>)Repositories[typeof(T)];
        }
    }
}
