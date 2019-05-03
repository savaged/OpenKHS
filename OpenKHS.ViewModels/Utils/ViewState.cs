using GalaSoft.MvvmLight;

using OpenKHS.Interfaces;

namespace OpenKHS.ViewModels.Utils
{
    public class ViewState : ViewModelBase, IViewState
    {
        #region Threadsafe Singleton

        private static volatile IViewState _default;
        private static readonly object _threadSaftyLock = new object();

        static ViewState() { }

        private ViewState() { }

        public static IViewState Default
        {
            get
            {
                if (_default == null)
                {
                    lock (_threadSaftyLock)
                    {
                        if (_default == null)
                        {
                            _default = new ViewState();
                        }
                    }
                }
                return _default;
            }
        }

        #endregion

        private bool _isBusy;

        public virtual bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(IsNotBusy));
            }
        }

        public bool IsNotBusy => !IsBusy;
    }
}
