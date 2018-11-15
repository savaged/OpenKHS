using System;
using System.Linq;
using OpenKHS.Data;
using OpenKHS.Models;
using System.Collections.Generic;
using System.ComponentModel;
using OpenKHS.ViewModels.Utils;

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
            
            LocalSpeakers = new UserInputLookup<LocalSpeaker>();

            Congregations = new UserInputLookup<Congregation>();
            
            Initialise(Repository.Index(), null);
            LoadLookups();

            Congregations.PropertyChanged += Congregations_PropertyChanged;
            PropertyChanged += OnPropertyChanged;
        }

        public override void Cleanup()
        {
            Congregations.PropertyChanged -= Congregations_PropertyChanged;
            PropertyChanged -= OnPropertyChanged;
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
        }

        private void LoadCongregations()
        {
            Congregations.Clear();
            Congregations.Add(_localCong);

            var neighbouringCongs = _neighbouringCongRepo.Index().OrderBy(c => c.Name);
            foreach (var c in neighbouringCongs)
            {
                Congregations.Add(c);
            }
        }

        private void LoadSpeakers()
        {
            LocalSpeakers.Clear();
            if (Congregations.SelectedItem.IsLocal)
            {
                var localSpeakers = _localCong.Members
                    .Where(m => m.PublicSpeaker).ToList();

                foreach (var congMember in localSpeakers)
                {
                    var speaker = new LocalSpeaker
                    {
                        Id = congMember.Id,
                        Name = congMember.Name,
                        Congregation = congMember.Congregation
                    };
                    LocalSpeakers.Add(speaker);
                }
            }
            else
            {
                // TODO load speakers for neighbouring cong
            }
        }

        protected override void AddModelObjectToDbContext()
        {
            if (ModelObject != null && !string.IsNullOrEmpty(ModelObject.Name))
            {
                Repository.Store(ModelObject);
            }
        }

        public UserInputLookup<Congregation> Congregations { get; private set; }

        public UserInputLookup<LocalSpeaker> LocalSpeakers { get; private set; }

        public bool IsSpeakerSelected => SelectedItem?.LocalSpeaker != null ||
            SelectedItem?.VisitingSpeaker != null;

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
                LoadSpeakers();
            }
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SelectedItem) && IsItemSelected)
            {
                if (ModelObject == null)
                {
                    throw new ArgumentNullException(
                        "Expected Selected Item and Model Object to be in sync!");
                }
                if (IsSpeakerSelected)
                {
                    Save();
                }
                LoadLookups();
            }
        }
    }
}