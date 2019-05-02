using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using OpenKHS.Universal.Core.Models;

namespace OpenKHS.Universal.Core.Services
{
    // This class holds sample data used by some generated pages to show how they can be used.
    // TODO WTS: Delete this file once your app is using real data.
    public static class SampleDataService
    {
        private static IEnumerable<SampleOrder> Index()
        {
            // The following is order summary data
            var data = new ObservableCollection<SampleOrder>
            {
                new SampleOrder
                {
                    Id = 70,
                    WeekStarting = new DateTime(2017, 05, 24),
                    Name = "Name F"
                },
                new SampleOrder
                {
                    Id = 71,
                    WeekStarting = new DateTime(2017, 05, 24),
                    Name = "Name CC"
                },
                new SampleOrder
                {
                    Id = 72,
                    WeekStarting = new DateTime(2017, 06, 03),
                    Name = "Name Z"
                },
                new SampleOrder
                {
                    Id = 73,
                    WeekStarting = new DateTime(2017, 06, 05),
                    Name = "Name Y"
                },
                new SampleOrder
                {
                    Id = 74,
                    WeekStarting = new DateTime(2017, 06, 07),
                    Name = "Name H"
                },
                new SampleOrder
                {
                    Id = 75,
                    WeekStarting = new DateTime(2017, 06, 07),
                    Name = "Name F"
                },
                new SampleOrder
                {
                    Id = 76,
                    WeekStarting = new DateTime(2017, 06, 11),
                    Name = "Name I"
                },
                new SampleOrder
                {
                    Id = 77,
                    WeekStarting = new DateTime(2017, 06, 14),
                    Name = "Name BB"
                },
                new SampleOrder
                {
                    Id = 78,
                    WeekStarting = new DateTime(2017, 06, 14),
                    Name = "Name A"
                },
                new SampleOrder
                {
                    Id = 79,
                    WeekStarting = new DateTime(2017, 06, 18),
                    Name = "Name K"
                },
            };

            return data;
        }

        // TODO WTS: Remove this once your MasterDetail pages are displaying real data.
        public static async Task<IEnumerable<SampleOrder>> GetSampleModelDataAsync()
        {
            await Task.CompletedTask;

            return Index();
        }
    }
}
