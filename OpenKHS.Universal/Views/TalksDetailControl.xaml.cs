using System;

using OpenKHS.Universal.Core.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace OpenKHS.Universal.Views
{
    public sealed partial class TalksDetailControl : UserControl
    {
        public SampleOrder MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as SampleOrder; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(SampleOrder), typeof(TalksDetailControl), new PropertyMetadata(null, OnMasterMenuItemPropertyChanged));

        public TalksDetailControl()
        {
            InitializeComponent();
        }

        private static void OnMasterMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as TalksDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
