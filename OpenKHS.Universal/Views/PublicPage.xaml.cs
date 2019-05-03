using System;
using Microsoft.Toolkit.Uwp.UI.Controls;
using OpenKHS.Universal.ViewModels;
using OpenKHS.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace OpenKHS.Universal.Views
{
    public sealed partial class PublicPage : Page
    {
        private PublicViewModel ViewModel
        {
            get { return ViewModelLocator.Current.PublicViewModel; }
        }

        public PublicPage()
        {
            InitializeComponent();
            Loaded += PublicPage_Loaded;
        }

        private async void PublicPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadDataAsync(
                MasterDetailsViewControl.ViewState == MasterDetailsViewState.Both);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            // Workaround for issue on MasterDetail Control. Find More info at https://github.com/Microsoft/WindowsTemplateStudio/issues/2738
            ViewModel.Selected = null;
        }
    }
}
