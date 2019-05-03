using System;

using OpenKHS.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace OpenKHS.Universal.Views
{
    public sealed partial class PublicDetailControl : UserControl
    {
        public SampleModel MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as SampleModel; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(SampleModel), typeof(PublicDetailControl), new PropertyMetadata(null, OnMasterMenuItemPropertyChanged));

        public PublicDetailControl()
        {
            InitializeComponent();
        }

        private static void OnMasterMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as PublicDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
