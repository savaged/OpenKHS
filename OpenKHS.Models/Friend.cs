
using System;
using System.Collections.Generic;

namespace OpenKHS.Models
{
    public class Friend
    {
        private AssignmentTally _assignmentTally;

        public Friend()
        {
            _assignmentTally = new AssignmentTally();
        }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public Privileges Privileges { get; set; }

        public List<TimeSpan> UnavailablePeriods { get; set; }

        public AssignmentTally AssignmentTally { get => _assignmentTally; set { _assignmentTally = value; } }
    }
}
