using System;
using System.Linq;
using OpenKHS.Data;
using OpenKHS.Models;
using OpenKHS.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OpenKHS.ViewModels
{
    public class PublicTalksViewModel : IndexBoundViewModelBase<PublicTalk>
    {
        private readonly PublicTalkOutlineRepository _outlinesRepo;
        private PublicTalkOutline _selectedPublicTalkOutline;

        public PublicTalksViewModel(DatabaseContext dbContext) : base(dbContext)
        {
            _outlinesRepo = new PublicTalkOutlineRepository();
            LoadLookups();
            Initialise(Repository.Index(), null);
        }

        protected void LoadLookups()
        {
            if (_outlinesRepo != null && PublicTalkOutlines == null)
            {
                PublicTalkOutlines = _outlinesRepo.Index();
                // TODO load Congregations = 
            }
        }

        protected override void AddModelObjectToDbContext()
        {
            if (ModelObject != null && !string.IsNullOrEmpty(ModelObject.Title))
            {
                Repository.Store(ModelObject);
            }
        }

        public IList<PublicTalkOutline> PublicTalkOutlines { get; private set; }

        public ObservableCollection<PublicTalkOutline> Congregations { get; private set; }

        public PublicTalkOutline SelectedPublicTalkOutline
        {
            get => _selectedPublicTalkOutline;
            set
            {
                Set(ref _selectedPublicTalkOutline, value);
                var match = Index.Where(
                    p => p.PublicTalkOutline.Id == SelectedPublicTalkOutline.Id).Last();
                if (match == null)
                {
                    New();
                }
                else
                {
                    SelectedItem = match;
                }
            }
        }
    }
}
