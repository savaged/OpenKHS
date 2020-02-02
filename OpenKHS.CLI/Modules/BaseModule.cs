using System;
using System.Threading.Tasks;

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

        public abstract Task LoadAsync(string entity);
    }

    public class NullModule : IModule
    {
        public async Task LoadAsync(string entity)
        {
            await Task.CompletedTask;
        }
    }
}