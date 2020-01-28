using System;
using System.Collections.Generic;
using System.Linq;
using OpenKHS.Data;
using OpenKHS.Models;

namespace OpenKHS.CLI.Modules
{
    public class LocalCongregationAdmin : IModule
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IDbContextFactory _dbContextFactory;

        public LocalCongregationAdmin(
            IFeedbackService feedbackService,
            IDbContextFactory dbContextFactory)
        {
            _feedbackService = feedbackService ??
                throw new ArgumentNullException(nameof(feedbackService));
            _dbContextFactory = dbContextFactory;
            throw new ArgumentNullException(nameof(dbContextFactory));
        }

        public void Load()
        {
            IList<LocalCongregationMember> index = null;
            using (var context = _dbContextFactory.Create())
            {
                index = context.LocalCongregationMembers.ToList();
            }
            _feedbackService.Present("List");
        }

    }
}