using GalaSoft.MvvmLight.Ioc;
using OpenKHS.Universal.Services;
using OpenKHS.Universal.Views;
using Windows.UI.Xaml.Data;

namespace OpenKHS.Universal.ViewModels
{
    [Bindable]
    public class ViewModelLocator
    {
        private static ViewModelLocator _current;

        public static ViewModelLocator Current => _current ??
            (_current = new ViewModelLocator());

        private ViewModelLocator()
        {
            SimpleIoc.Default.Register(
                () => new NavigationServiceEx());
            SimpleIoc.Default.Register<ShellViewModel>();
            Register<CongregationViewModel, CongregationPage>();
            Register<CLMMViewModel, CLMMPage>();
            Register<PublicViewModel, PublicPage>();
            Register<TalksViewModel, TalksPage>();
            Register<SettingsViewModel, SettingsPage>();
        }

        public SettingsViewModel SettingsViewModel => 
            SimpleIoc.Default.GetInstance<SettingsViewModel>();

        public TalksViewModel TalksViewModel => 
            SimpleIoc.Default.GetInstance<TalksViewModel>();

        public PublicViewModel PublicViewModel => 
            SimpleIoc.Default.GetInstance<PublicViewModel>();

        public CLMMViewModel CLMMViewModel => 
            SimpleIoc.Default.GetInstance<CLMMViewModel>();

        public CongregationViewModel CongregationViewModel => 
            SimpleIoc.Default.GetInstance<CongregationViewModel>();

        public ShellViewModel ShellViewModel => 
            SimpleIoc.Default.GetInstance<ShellViewModel>();

        public NavigationServiceEx NavigationService => 
            SimpleIoc.Default.GetInstance<NavigationServiceEx>();

        public void Register<VM, V>()
            where VM : class
        {
            SimpleIoc.Default.Register<VM>();

            NavigationService.Configure(
                typeof(VM).FullName, typeof(V));
        }
    }
}
