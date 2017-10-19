using System;
using MvvmDialogs;

namespace OpenKHS.Interfaces
{
    public interface IViewManager
    {
        event EventHandler RequestClose;
        IDialogService DialogService { get; }
        IDataGateway DataGateway { get; }
    }
}
