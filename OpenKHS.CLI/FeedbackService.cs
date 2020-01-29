using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using BetterConsoleTables;
using Colorful;
using OpenKHS.Models;
using OpenKHS.Models.Utils;

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

        public void Present<T>(IList<T> index) where T : IModel
        {
            var table = new Table(TableConfiguration.Markdown());
            table.From(index);
            Console.WriteLine(table.ToString());
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