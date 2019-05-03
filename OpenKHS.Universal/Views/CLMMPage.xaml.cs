﻿using OpenKHS.Universal.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace OpenKHS.Views
{
    public sealed partial class CLMMPage : Page
    {
        private CLMMViewModel ViewModel =>
            ViewModelLocator.Current.CLMMViewModel;

        public CLMMPage()
        {
            InitializeComponent();
            Loaded += CLMMPage_Loaded;
        }

        private async void CLMMPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel?.LoadDataAsync();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            // Workaround for issue on MasterDetail Control. Find More info at https://github.com/Microsoft/WindowsTemplateStudio/issues/2738
            ViewModel.Selected = null;
        }
    }
}
