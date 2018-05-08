using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenKHS.Data;
using OpenKHS.Interfaces;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public class PublicTalksViewModel : LocalViewModelBase, IViewModel
    {
        public PublicTalksViewModel()
        {
            Index = new ObservableCollection<PublicTalkOutline>();
            // TODO load external file via repo to the index
        }

        public ObservableCollection<PublicTalkOutline> Index { get; set; }
    }
}
