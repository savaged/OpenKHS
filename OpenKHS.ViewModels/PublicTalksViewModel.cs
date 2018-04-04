using System;
using System.Collections.Generic;
using OpenKHS.Interfaces;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public class PublicTalksViewModel : ModelBoundViewModelBase<PublicTalk>
    {
        public PublicTalksViewModel(IDataGateway dataGateway) : base(dataGateway)
        {
        }
    }
}
