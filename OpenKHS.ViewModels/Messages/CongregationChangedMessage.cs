using System;
using GalaSoft.MvvmLight.Messaging;
using OpenKHS.Models;
using System.Collections.Generic;

namespace OpenKHS.ViewModels.Messages
{
    public class CongregationChangedMessage : MessageBase
    {
        public CongregationChangedMessage(IList<Friend> members)
        {
            Members = members;
        }

        public IList<Friend> Members { get; }
    }
}
