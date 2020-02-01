using System;
using System.Collections.Generic;

namespace OpenKHS.Models
{
    public abstract class Schedule : ModelBase
    {
        private DateTime _weekStarting;

        public Schedule()
        {
            Assignments = new List<Assignment>();
        }

        public IList<Assignment> Assignments { get; set; }

        public DateTime WeekStarting 
        {
            get => _weekStarting;
            set => Set(ref _weekStarting, value);
        }

    }
}