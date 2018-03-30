using System;
using OpenKHS.Interfaces;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public class PublicTalksViewModel : ModelBoundViewModelBase<PublicTalk>
    {
        private readonly IDataGateway _dataGateway;

        public PublicTalksViewModel(IDataGateway dataGateway)
        {
            _dataGateway = dataGateway;
        }

        public bool New()
        {
            throw new NotImplementedException();
        }
    }
}
