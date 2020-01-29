using System;
using OpenKHS.Data;

namespace OpenKHS.CLI.Modules
{
    public abstract class BaseModule : IModule
    {
        protected IFeedbackService FeedbackService { get; }

        public BaseModule(
            IFeedbackService feedbackService)
        {
            FeedbackService = feedbackService ??
                throw new ArgumentNullException(nameof(feedbackService));
        }

        public abstract void Load();
    }
}