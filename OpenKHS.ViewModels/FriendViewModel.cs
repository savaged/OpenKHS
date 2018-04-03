using System;
using MvvmDialogs;
using OpenKHS.Models;
using OpenKHS.Interfaces;

namespace OpenKHS.ViewModels
{
    class FriendViewModel<IFriend> : DialogViewModelBase<Friend>
    {
        public FriendViewModel(IDataGateway dataGateway, IDialogService dialogService, Friend friend)
        {
            ModelObject = friend;
        }
    }
}
