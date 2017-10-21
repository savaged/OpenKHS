using OpenKHS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenKHS.ViewModels
{
    public class FriendFormDialogViewModel : DialogViewModelBase
    {
        private IDataGateway _dataGateway;

        public FriendFormDialogViewModel(IDataGateway dataGateway)
        {
            _dataGateway = dataGateway;
        }
        
    }
}
