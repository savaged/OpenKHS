using GalaSoft.MvvmLight;
using Microsoft.Toolkit.Uwp.UI.Controls;
using OpenKHS.Universal.Core.Models;
using OpenKHS.Universal.Core.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace OpenKHS.Universal.ViewModels
{
    public class PublicViewModel : ViewModelBase
    {
        private SampleOrder _selected;

        public SampleOrder Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }

        public ObservableCollection<SampleOrder> Index { get; private set; } = new ObservableCollection<SampleOrder>();

        public PublicViewModel()
        {
        }

        public async Task LoadDataAsync(MasterDetailsViewState viewState)
        {
            Index.Clear();

            var data = await SampleDataService.GetSampleModelDataAsync();

            foreach (var item in data)
            {
                Index.Add(item);
            }

            if (viewState == MasterDetailsViewState.Both)
            {
                Selected = Index.First();
            }
        }
    }
}
