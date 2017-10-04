using System;
using MvvmDialogs;

namespace OpenKHS.Interfaces
{
    interface IViewManager
    {
        event EventHandler RequestClose;
        IDialogService DialogService { get; }
    }
}
