using Ninject;
using System;
using System.Windows;
using OpenKHS.Interfaces;

namespace OpenKHS.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IMainView
    {
        public MainWindow()
        {
            InitializeComponent();
            SourceInitialized += Window_SourceInitialized;
        }

        [Inject]
        public MessageBoxService MessageBoxService { get; set; }

        private void Window_SourceInitialized(object sender, EventArgs e)
        {
            var vm = ((IMainViewModel) DataContext);
            vm.RequestClose += OnRequestClose;

            CongregationView.DataContext = vm.CongregationVM;
            PublicTalksView.DataContext = vm.PublicTalksVM;
            PmScheduleView.DataContext = vm.PmScheduleVM;
            ClmmScheduleView.DataContext = vm.ClmmScheduleVM;
        }
        
        public void OnRequestClose(object sender, EventArgs args)
        {
            Application.Current.Shutdown();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var vm = ((IMainViewModel)DataContext);
            vm.CloseView();
        }
    }
}
