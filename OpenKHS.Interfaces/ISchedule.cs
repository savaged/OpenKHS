﻿
using System;

namespace OpenKHS.Interfaces
{
    public interface ISchedule : IModel
    {
        void Publish();

        int Week { get; set; }
    }
}
