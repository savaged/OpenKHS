using OpenKHS.Interfaces;
using System;

namespace OpenKHS.ViewModels
{
    public class PublicTalksViewModel : ViewModelBase, IDataViewModel
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
