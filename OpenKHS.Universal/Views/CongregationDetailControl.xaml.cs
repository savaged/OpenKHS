using System;

using OpenKHS.Universal.Core.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace OpenKHS.Universal.Views
{
    public sealed partial class CongregationDetailControl : UserControl
    {
        public SampleOrder MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as SampleOrder; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(SampleOrder), typeof(CongregationDetailControl), new PropertyMetadata(null, OnMasterMenuItemPropertyChanged));

        public CongregationDetailControl()
        {
            InitializeComponent();
        }

        private static void OnMasterMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as CongregationDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
