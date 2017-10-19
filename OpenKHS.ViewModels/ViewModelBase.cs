using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Reflection;
using log4net;
using OpenKHS.Interfaces;

namespace OpenKHS.ViewModels
{
    /// <summary>
    /// Implements INotifyPropertyChanged for all ViewModel
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        protected static readonly ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public IDataGateway DataGateway { get; private set; }

        public ViewModelBase() { }

        public ViewModelBase(IDataGateway dataGateway)
        {
            DataGateway = dataGateway;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
