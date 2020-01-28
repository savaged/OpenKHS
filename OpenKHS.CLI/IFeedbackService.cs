using System.Collections.Generic;
using OpenKHS.Models;

namespace OpenKHS.CLI
{
    public interface IFeedbackService
    {
        void Present(
            string feedback,
            FeedbackContext context = FeedbackContext.Information);

        void Present<T>(IList<T> index) where T : IModel;
    }

    public enum FeedbackContext
    {
        Information,
        Question,
        Warning,
        Error,
        Banner
    }
}