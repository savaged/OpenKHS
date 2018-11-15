using System;
using System.Linq;
using OpenKHS.Data;
using OpenKHS.Models;
using System.Collections.Generic;
using System.ComponentModel;
using OpenKHS.ViewModels.Utils;
using System.Collections.ObjectModel;

namespace OpenKHS.ViewModels
{
    public class PublicTalksViewModel : IndexBoundViewModelBase<PublicTalk>
    {
        private NeighbouringCongregationRepository _neighbouringCongRepo;
        private LocalCongregation _localCong;

        public PublicTalksViewModel(DatabaseContext dbContext) : base(dbContext)
        {
            var localCongMemberRepo = 
                Repositories[typeof(LocalCongregationMember)] 
                as LocalCongregationMemberRepository;
            _localCong = new LocalCongregation(localCongMemberRepo.Index());

            _neighbouringCongRepo = Repositories[typeof(Congregation)] 
                as NeighbouringCongregationRepository;
            
            LocalSpeakers = new ObservableCollection<LocalSpeaker>();

            Congregations = new UserInputLookup<Congregation>();
            VisitingSpeakers = new UserInputLookup<VisitingSpeaker>();

            Initialise(Repository.Index(), null);
            LoadLookups();

            Congregations.PropertyChanged += Congregations_PropertyChanged;
        }

        public override void Cleanup()
        {
            Congregations.PropertyChanged -= Congregations_PropertyChanged;
            base.Cleanup();
        }

        protected override void Initialise(IList<PublicTalk> data, PublicTalk defaultFirstItem)
        {
            if (data == null || data.Count == 0)
            {
                var outlines = new PublicTalkOutlineRepository().Index();
                foreach (var o in outlines)
                {
                    data.Add(new PublicTalk { Id = o.Id, PublicTalkOutline = o });
                }
            }
            base.Initialise(data, defaultFirstItem);
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
            var localSpeakers = _localCong.Members
                    .Where(m => m.PublicSpeaker).ToList();

            foreach (var congMember in localSpeakers)
            {
                var speaker = new LocalSpeaker
                {
                    Id = congMember.Id,
                    Name = congMember.Name
                };
                LocalSpeakers.Add(speaker);
            }
        }

        private void LoadVisitingSpeakers()
        {
            // TODO load visiting speakers
        }

        protected override void AddModelObjectToDbContext()
        {
            if (ModelObject != null && !string.IsNullOrEmpty(ModelObject.Name))
            {
                Repository.Store(ModelObject);
            }
        }

        public ObservableCollection<LocalSpeaker> LocalSpeakers { get; private set; }

        public UserInputLookup<Congregation> Congregations { get; private set; }

        public UserInputLookup<VisitingSpeaker> VisitingSpeakers { get; private set; }

        private void Congregations_PropertyChanged(object sender, PropertyChangedEventArgs e)
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
    }
}