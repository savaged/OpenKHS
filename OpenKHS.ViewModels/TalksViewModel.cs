using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using GalaSoft.MvvmLight;

using OpenKHS.Interfaces;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public class TalksViewModel : ViewModelBase
    {
        private readonly IRepositoryLookup _repositoryLookup;
        private SampleModel _selected;

        public TalksViewModel(
            IRepositoryLookup repositoryLookup)
        {
            _repositoryLookup = repositoryLookup;
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

            var repository = _repositoryLookup.GetRelatedRepository<SampleModel>();

            var data = await Task.Run(() => repository.Index());

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
