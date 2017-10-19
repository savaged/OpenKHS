using System;
using MvvmDialogs;

namespace OpenKHS.Interfaces
{
    public interface IViewManager : IViewModel
    {
        event EventHandler RequestClose;
        IDialogService DialogService { get; }
        IDataGateway Gateway { get; }
    }
}
