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
        private SampleModel _selected;

        public PublicViewModel()
        {
            Index = new ObservableCollection<SampleModel>();
        }

        public SampleModel Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }

        public ObservableCollection<SampleModel> Index { get; set; }

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
