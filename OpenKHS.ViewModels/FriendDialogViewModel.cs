using System;
using MvvmDialogs;
using OpenKHS.Models;
using OpenKHS.Interfaces;

namespace OpenKHS.ViewModels
{
    class FriendDialogViewModel : DialogViewModelBase
    {
        public FriendDialogViewModel(IDataGateway dataGateway, IDialogService dialogService, Friend friend)
        {
            // TODO wrap model properties in observable collection(s) which go in datagrids and see if that will suffice for editing
        }
    }
}
