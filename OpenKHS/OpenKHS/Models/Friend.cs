﻿
using System;
using System.Collections.Generic;

namespace OpenKHS.Models
{
    public class Friend
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public Privileges Privileges { get; set; }

        public List<TimeSpan> UnavailablePeriods { get; set; }
    }
}
