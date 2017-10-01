using System;
using MvvmDialogs;

namespace OpenKHS.Interfaces
{
    interface IViewManager
    {
        event Action RequestClose;
        IDialogService DialogService { get; }
    }
}
