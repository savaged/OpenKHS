using System;
using GalaSoft.MvvmLight;

namespace OpenKHS.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(
            LocalCongregationAdminViewModel localCongregationAdminViewModel)
        {
            LocalCongregationAdminViewModel = localCongregationAdminViewModel ??
                throw new ArgumentNullException(nameof(localCongregationAdminViewModel));
        }

        public LocalCongregationAdminViewModel LocalCongregationAdminViewModel
        { get; }

        public void Load()
        {
            LocalCongregationAdminViewModel.Load();
        }

    }
}