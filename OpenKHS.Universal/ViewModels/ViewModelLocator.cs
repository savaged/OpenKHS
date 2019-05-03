using GalaSoft.MvvmLight.Ioc;
using OpenKHS.Data;
using OpenKHS.Interfaces;
using OpenKHS.Universal.Services;
using OpenKHS.Universal.Views;
using OpenKHS.ViewModels;
using OpenKHS.ViewModels.Utils;
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
            #region UWP specific bindings

            SimpleIoc.Default.Register(
                () => new NavigationServiceEx());
            SimpleIoc.Default.Register<ShellViewModel>();

            Register<SettingsViewModel, SettingsPage>();

            #endregion

            //SimpleIoc.Default.Register<DatabaseContext>();
            //SimpleIoc.Default
            //    .Register<IRepositoryLookup, RepositoryLookup>();

            Register<HomeViewModel, HomePage>();
            Register<CongregationViewModel, CongregationPage>();
            Register<CLMMViewModel, CLMMPage>();
            Register<PublicViewModel, PublicPage>();
            Register<TalksViewModel, TalksPage>();
        }

        public HomeViewModel HomeViewModel =>
            SimpleIoc.Default.GetInstance<HomeViewModel>();

        public SettingsViewModel SettingsViewModel => 
            SimpleIoc.Default.GetInstance<SettingsViewModel>();

        public ShellViewModel ShellViewModel =>
            SimpleIoc.Default.GetInstance<ShellViewModel>();

        public NavigationServiceEx NavigationService =>
            SimpleIoc.Default.GetInstance<NavigationServiceEx>();


        public TalksViewModel TalksViewModel =>
            SimpleIoc.Default.GetInstance<TalksViewModel>();

        public PublicViewModel PublicViewModel =>
            SimpleIoc.Default.GetInstance<PublicViewModel>();

        public CLMMViewModel CLMMViewModel =>
            SimpleIoc.Default.GetInstance<CLMMViewModel>();

        public CongregationViewModel CongregationViewModel =>
            SimpleIoc.Default.GetInstance<CongregationViewModel>();


        public void Register<VM, V>()
            where VM : class
        {
            SimpleIoc.Default.Register<VM>();

            NavigationService.Configure(
                typeof(VM).FullName, typeof(V));
        }
    }
}
