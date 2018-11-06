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
            Initialise(Repository.Index(), null);

            Congregations = new UserInputLookup<Congregation>();
            Congregations.PropertyChanged += Congregations_PropertyChanged;
            LoadLookups();

            Speakers = new UserInputLookup<PmSpeaker>();
            Speakers.PropertyChanged += Speakers_PropertyChanged;
        }

        public override void Cleanup()
        {
            Congregations.PropertyChanged -= Congregations_PropertyChanged;
            Speakers.PropertyChanged -= Speakers_PropertyChanged;
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
            if (Congregations?.Count == 0)
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
            if (Congregations.SelectedItem != null)
            {
                if (Congregations.SelectedItem.IsLocal)
                {
                    var localSpeakers = _localCong.Members.Where(m => m.PublicSpeaker).ToList();
                    foreach (var congMember in localSpeakers)
                    {
                        var speaker = new PmSpeaker
                        {
                            Id = congMember.Id,
                            Name = congMember.Name,
                            Congregation = congMember.Congregation
                        };
                        Speakers.Add(speaker);
                    }
                }
                else
                {
                    // TODO load speakers for neighbouring cong
                }
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

        public UserInputLookup<PmSpeaker> Speakers { get; private set; }

        public PmSpeaker SelectedSpeaker
        {
            get => SelectedItem?.Speaker as PmSpeaker;
            set
            {
                if (SelectedItem == null)
                {
                    throw new ArgumentNullException("Expected to have a SelectedItem!");
                }
                SelectedItem.Speaker = value;
                RaisePropertyChanged(nameof(IsSpeakerSelected));
            }
        }
        public bool IsSpeakerSelected => SelectedSpeaker != null;

        private void Congregations_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Congregations.NewItem))
            {
                var @new = new NeighbouringCongregation { Name = Congregations.SelectedItem.Name };
                _neighbouringCongRepo.Store(@new);
                _neighbouringCongRepo.Save();
                LoadCongregations();
            }
            else if (e.PropertyName == nameof(Congregations.SelectedItem))
            {
                LoadSpeakers();
            }
        }

        private void Speakers_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // TODO code this
        }
    }
}