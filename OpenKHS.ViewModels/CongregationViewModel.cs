using OpenKHS.Models;
using OpenKHS.Data;
using OpenKHS.ViewModels.Messages;
using System.Collections.Generic;

namespace OpenKHS.ViewModels
{
    public class CongregationViewModel : IndexBoundViewModelBase<Friend>
    {
        public CongregationViewModel(DatabaseContext dbContext) : base(dbContext)
        {
            Initialise(DbContext.Index(), new Friend());
            Index.CollectionChanged += IndexChanged;
        }

        public override void Cleanup()
        {
            Index.CollectionChanged -= IndexChanged;
            base.Cleanup();
        }

        public override bool IsItemSelected
        {
            get => base.IsItemSelected && !string.IsNullOrEmpty(SelectedItem.Name);
        }

        protected override void AddModelObjectToDbContext()
        {
            if (ModelObject != null && !string.IsNullOrEmpty(ModelObject.Name)) DbContext.Store(ModelObject);
        }

        private void IndexChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var members = new List<Friend>();
            foreach (var member in Index)
            {
                members.Add(member);
            }
            MessengerInstance.Send(new CongregationChangedMessage(members));
        }
    }
}
