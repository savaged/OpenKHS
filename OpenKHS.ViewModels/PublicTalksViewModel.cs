using OpenKHS.Data;
using OpenKHS.Interfaces;
using OpenKHS.Models;
using OpenKHS.ViewModels.Utils;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace OpenKHS.ViewModels
{
    public class PublicTalksViewModel : IndexBoundViewModelBase<PublicTalk>
    {
        private NeighbouringCongregationRepository _neighbouringCongRepo;
        private LocalCongregationMemberRepository _localCongMemberRepo;
        private bool _isLoading;

        public PublicTalksViewModel(IRepositoryLookup repositoryLookup)
            : base(repositoryLookup)
        {
            _localCongMemberRepo =
                Repositories[typeof(LocalCongregationMember)]
                as LocalCongregationMemberRepository;
            
            _neighbouringCongRepo = Repositories[typeof(Congregation)]
                as NeighbouringCongregationRepository;

            LocalSpeakers = new ObservableCollection<LocalCongregationMember>();

            Congregations = new UserInputLookup<Congregation>();
            VisitingSpeakers = new UserInputLookup<VisitingSpeaker>();

            Congregations.PropertyChanged += OnCongregationsPropertyChanged;
        }

        public override void Cleanup()
        {
            Congregations.PropertyChanged -= OnCongregationsPropertyChanged;
            base.Cleanup();
        }

        public void Load()
        {
            _isLoading = true;
            LoadLookups();
            Initialise(Repository.Index(), null);
            _isLoading = false;
        }

        protected void LoadLookups()
        {
            if (Congregations.Count == 0)
            {
                LoadCongregations();
            }
            LoadLocalSpeakers();
        }

        private void LoadCongregations()
        {
            Congregations.Clear();

            var neighbouringCongs = _neighbouringCongRepo.Index()
                .OrderBy(c => c.Name);
            foreach (var c in neighbouringCongs)
            {
                Congregations.Add(c);
            }
        }

        private void LoadLocalSpeakers()
        {
            LocalSpeakers.Clear();
            var localCong = new LocalCongregation(_localCongMemberRepo.Index());
            var localSpeakers = localCong.Members
                    .Where(m => m.PublicSpeaker).ToList();

            foreach (var congMember in localSpeakers)
            {
                LocalSpeakers.Add(congMember);
            }
        }

        private void LoadVisitingSpeakers()
        {
            // TODO load visiting speakers
        }

        protected override void AddModelObjectToDbContext()
        {
            IsDirty = true;
        }

        public ObservableCollection<LocalCongregationMember> LocalSpeakers { get; private set; }

        public UserInputLookup<Congregation> Congregations { get; private set; }

        public UserInputLookup<VisitingSpeaker> VisitingSpeakers { get; private set; }

        private void OnCongregationsPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Congregations.NewItem))
            {
                var @new = new NeighbouringCongregation { Name = Congregations.SelectedItem.Name };
                _neighbouringCongRepo.Store(@new);
                _neighbouringCongRepo.Save();
                LoadCongregations();
            }
            else if (e.PropertyName == nameof(Congregations.SelectedItem)
                && Congregations.Count > 0)
            {
                LoadVisitingSpeakers();
            }
        }

        protected override void OnModelObjectPropertyChanged(
            object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(SelectedItem.LocalSpeaker):
                case nameof(SelectedItem.VisitingSpeaker):
                    if (!_isLoading)
                    {
                        AddModelObjectToDbContext();
                        Save();
                    }
                    break;
            }
        }
    }
}