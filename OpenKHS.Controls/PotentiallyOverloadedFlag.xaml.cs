using System;
using System.Windows;
using OpenKHS.Interfaces;

namespace OpenKHS.Controls
{
    public partial class PotentiallyOverloadedFlag
    {
        public PotentiallyOverloadedFlag()
        {
            InitializeComponent();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            {
                var friend = (ICongregationMember)DataContext;
                if (friend.IsPotentiallyOverloaded)
                {
                    TxtFlag.Visibility = Visibility.Visible;
                }
                else
                {
                    TxtFlag.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                TxtFlag.Visibility = Visibility.Collapsed;
            }
        }
    }
}
