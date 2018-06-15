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

        public PublicTalksViewModel(DatabaseContext dbContext) : base(dbContext)
        {
            _neighbouringCongRepo = Repositories[typeof(Congregation)] as NeighbouringCongregationRepository;
            Initialise(Repository.Index(), null);
            PropertyChanged += OnPropertyChanged;
            Congregations = new UserInputLookup<Congregation>();
            Congregations.PropertyChanged += Congregations_PropertyChanged;
            LoadLookups();
        }

        public override void Cleanup()
        {
            PropertyChanged -= OnPropertyChanged;
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
            if (Congregations?.Count == 0)
            {
                LoadCongregations();
            }
        }

        private void LoadCongregations()
        {
            var memberRepo = Repositories[typeof(LocalCongregationMember)] as LocalCongregationMemberRepository;
            var localCongregation = new LocalCongregation(memberRepo.Index());
            Congregations.Clear();
            Congregations.Add(localCongregation);

            var neighbouringCongs = _neighbouringCongRepo.Index().OrderBy(c => c.Name);
            foreach (var c in neighbouringCongs)
            {
                Congregations.Add(c);
            }
        }

        private void LoadSpeakers()
        {
            // TODO load Repositories[typeof(VisitingSpeaker)] if not local else local.pmspeakers
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
            get => SelectedItem?.Friend as PmSpeaker;
            set
            {
                if (SelectedItem == null)
                {
                    throw new ArgumentNullException("Expected to have a SelectedItem!");
                }
                SelectedItem.Friend = value;
                RaisePropertyChanged(nameof(IsSpeakerSelected));
            }
        }
        public bool IsSpeakerSelected => SelectedSpeaker != null;

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SelectedItem) && IsSpeakerSelected)
            {
                LoadSpeakers();
            }
        }

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
                // TODO load speakers for selected cong
            }
        }
    }
}