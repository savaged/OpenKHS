using OpenKHS.Interfaces;
using System;

namespace OpenKHS.Models
{
    public class LocalBrother : CongregationMember, IBrother
    {
        public new bool Male { get => true; private set { } }
    }
}
