using System;
using System.Collections.Generic;
using System.Drawing;
using ConsoleTables;
using OpenKHS.Models;

namespace OpenKHS.CLI
{
    public class FeedbackService : IFeedbackService
    {
        private readonly Color _initialFg;

        public FeedbackService()
        {
            _initialFg = Colorful.Console.ForegroundColor;
        }

        public void Present(
            string feedback, 
            FeedbackContext context = FeedbackContext.Information)
        {
            var fg = GetColor(context);
            Colorful.Console.WriteLine(feedback, fg);
        }

        public void Present<T>(IList<T> index) where T : IModel
        {
            ConsoleTable.From(index).Write(Format.MarkDown);
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