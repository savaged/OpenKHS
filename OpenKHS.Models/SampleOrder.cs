using System;

namespace OpenKHS.Universal.Core.Models
{
    // TODO WTS: Remove this class once your pages/features are using your data.
    // This is used by the SampleDataService.
    // It is the model class we use to display data on pages like Grid, Chart, and Master Detail.
    public class SampleOrder
    {
        public long Id { get; set; }

        public DateTime WeekStarting { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name}";
        }
    }
}
