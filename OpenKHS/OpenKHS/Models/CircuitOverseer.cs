using OpenKHS.Interfaces;
using System;

namespace OpenKHS.Models
{
    public sealed class CircuitOverseer : Friend, IBrother
    {
        public Friend Wife { get; set; }

        public new bool Male { get => true; }
    }
}
