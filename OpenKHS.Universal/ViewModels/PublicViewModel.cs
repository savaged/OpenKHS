using GalaSoft.MvvmLight;
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

        public PublicViewModel()
        {
            Index = new ObservableCollection<SampleOrder>();
        }

        public SampleOrder Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }

        public ObservableCollection<SampleOrder> Index { get; set; }

        public async Task LoadDataAsync(bool selectFirstItemByDefault)
        {
            Index.Clear();

            var data = await SampleDataService.GetSampleModelDataAsync();

            foreach (var item in data)
            {
                Index.Add(item);
            }

            if (selectFirstItemByDefault)
            {
                Selected = Index.First();
            }
        }
    }
}
