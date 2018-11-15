﻿
using System;

namespace OpenKHS.Models
{
    /// <summary>
    /// Public Meeting Speaker from the local congregation
    /// </summary>
    public class LocalSpeaker : PmSpeaker 
    {
        public override string Congregation
        {
            get => "Local";
            set => throw new NotSupportedException();
        }
    }
}
