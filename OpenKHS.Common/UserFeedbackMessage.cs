using GalaSoft.MvvmLight.Messaging;

namespace OpenKHS.Common
{
    public class UserFeedbackMessage : MessageBase
    {
        public UserFeedbackMessage(
            object sender,
            string body,
            string header,
            UserFeedbackTypes feedbackType)
            : base(sender)
        {
            Body = body;
            Header = header;
            FeedbackType = feedbackType;
        }

        public string Body { get; }

        public string Header { get; }

        public UserFeedbackTypes FeedbackType { get; }
    }

    public enum UserFeedbackTypes
    {
        None = 0,
        Stop = 16,
        Question = 32,
        Warning = 48,
        Information = 64
    }
}
