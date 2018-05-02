using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace OpenKHS.Controls
{
    public static class UserControlExtensions
    {
        public static void OnIndexSelectionChanged(this UserControl @this, object sender, SelectionChangedEventArgs e)
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
