using System;

namespace OpenKHS.Models
{
    // TODO WTS: Remove this class once your pages/features are using your data.
    // This is used by the SampleDataService.
    // It is the model class we use to display data on pages like Grid, Chart, and Master Detail.
    public class SampleModel : ModelBase
    {
        public DateTime WeekStarting { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name}";
        }
    }
}
