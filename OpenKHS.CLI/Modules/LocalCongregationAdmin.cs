using System.Collections.Generic;
using System.Linq;
using OpenKHS.Data;
using OpenKHS.Models;

namespace OpenKHS.CLI.Modules
{
    public class LocalCongregationAdmin : BaseModule
    {
        public LocalCongregationAdmin(
            IFeedbackService feedbackService,
            IDbContextFactory dbContextFactory) 
            : base(feedbackService, dbContextFactory)
        {
        }

        public override void Load()
        {
            // TODO Move this to ViewModels (for reuse on different platforms)
            IList<LocalCongregationMember> index = null;
            using (var context = DbContextFactory.Create())
            {
                index = context.LocalCongregationMembers.ToList();
            }
            FeedbackService.Present(index);
        }

    }
}