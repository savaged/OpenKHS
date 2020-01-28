namespace OpenKHS.CLI
{
    public interface IFeedbackService
    {
        void Present(
            string feedback,
            FeedbackContext context = FeedbackContext.Information);
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