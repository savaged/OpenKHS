using System;
using MvvmDialogs;
using OpenKHS.Models;
using OpenKHS.Interfaces;

namespace OpenKHS.ViewModels
{
    class FriendDialogViewModel<IFriend> : DialogViewModelBase<Friend>
    {
        public FriendDialogViewModel(IDataGateway dataGateway, IDialogService dialogService, Friend friend)
        {
            ModelObject = friend;
        }
    }
}
