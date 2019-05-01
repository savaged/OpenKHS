using System;

using OpenKHS.Universal.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace OpenKHS.Universal.Views
{
    public sealed partial class CongregationPage : Page
    {
        private CongregationViewModel ViewModel
        {
            get { return ViewModelLocator.Current.CongregationViewModel; }
        }

        public CongregationPage()
        {
            InitializeComponent();
            Loaded += CongregationPage_Loaded;
        }

        private async void CongregationPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadDataAsync(MasterDetailsViewControl.ViewState);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            // Workaround for issue on MasterDetail Control. Find More info at https://github.com/Microsoft/WindowsTemplateStudio/issues/2738
            ViewModel.Selected = null;
        }
    }
}
