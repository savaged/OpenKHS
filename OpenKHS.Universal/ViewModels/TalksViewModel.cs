using GalaSoft.MvvmLight;
using OpenKHS.Models;
using OpenKHS.ViewModels.Utils;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace OpenKHS.Universal.ViewModels
{
    public class TalksViewModel : ViewModelBase
    {
        private SampleModel _selected;

        public TalksViewModel()
        {
            Index = new ObservableCollection<SampleModel>();
        }

        public SampleModel Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }

        public ObservableCollection<SampleModel> Index { get; set; }

        public async Task LoadDataAsync()
        {
            Index.Clear();

            var repository = RepositoryLookup.Default
                .GetRelatedRepository<SampleModel>();

            var data = await Task.Run(() => repository.Index());

            foreach (var item in data)
            {
                Index.Add(item);
            }

            if (Index.Count > 0)
            {
                Selected = Index.First();
            }
        }
    }
}
