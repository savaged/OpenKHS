
using OpenKHS.Interfaces;
using System;

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
            Close();
        }

        public new void Show()
        {
            base.Show();
        }

        public new object DataContext { get => base.DataContext; set { base.DataContext = value; } }
    }
}
