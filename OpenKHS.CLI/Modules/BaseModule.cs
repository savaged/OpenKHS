using System;
using OpenKHS.Data;

namespace OpenKHS.CLI.Modules
{
    public abstract class BaseModule : IModule
    {
        protected readonly IFeedbackService FeedbackService;
        protected readonly IDbContextFactory DbContextFactory;

        public BaseModule(
            IFeedbackService feedbackService,
            IDbContextFactory dbContextFactory)
        {
            FeedbackService = feedbackService ??
                throw new ArgumentNullException(nameof(feedbackService));
            DbContextFactory = dbContextFactory ??
                throw new ArgumentNullException(nameof(dbContextFactory));      
        }

        public abstract void Load();
    }
}