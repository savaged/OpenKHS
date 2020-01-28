using System.Drawing;
using Colorful;

namespace OpenKHS.CLI
{
    public class FeedbackService : IFeedbackService
    {
        private readonly Color _initialFg;

        public FeedbackService()
        {
            _initialFg = Console.ForegroundColor;
        }

        public void Present(
            string feedback, 
            FeedbackContext context = FeedbackContext.Information)
        {
            var fg = GetColor(context);
            Console.WriteLine(feedback, fg);
        }

        private Color GetColor(FeedbackContext context)
        {
            Color initial = _initialFg;
            var color = context switch
            {
                FeedbackContext.Error => Color.Red,
                FeedbackContext.Warning => Color.Orange,
                _ => initial
            };
            return color;
        }
    }

}