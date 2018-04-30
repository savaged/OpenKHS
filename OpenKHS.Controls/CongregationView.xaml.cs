using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace OpenKHS.Controls
{
    /// <summary>
    /// Interaction logic for CongregationView.xaml
    /// </summary>
    public partial class CongregationView : UserControl
    {
        public CongregationView()
        {
            InitializeComponent();
        }

        private void CongMembersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                var addedItem = e.AddedItems[0];
                var dataGrid = (DataGrid)sender;
                var i = dataGrid.Items.IndexOf(addedItem);
                var container = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(i);
                if (container != null)
                {
                    container.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                }
            }
        }
    }
}
