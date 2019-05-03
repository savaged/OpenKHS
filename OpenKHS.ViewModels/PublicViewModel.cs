using GalaSoft.MvvmLight;
using OpenKHS.Interfaces;
using OpenKHS.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace OpenKHS.Universal.ViewModels
{
    public class PublicViewModel : ViewModelBase
    {
        private readonly IModelRepository<SampleModel> _repository;
        private SampleModel _selected;

        public PublicViewModel(
            IRepositoryLookup repositoryLookup)
        {
            _repository = repositoryLookup.GetRelatedRepository<SampleModel>();
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

            var data = await Task.Run(() => _repository.Index());

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
