
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
            var vm = ((IViewManager)DataContext);
            vm.RequestClose += OnRequestClose;
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
