using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
