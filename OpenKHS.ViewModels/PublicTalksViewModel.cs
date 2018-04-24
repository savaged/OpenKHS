using System;
using System.Collections.Generic;
using OpenKHS.Data;
using OpenKHS.Interfaces;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public class PublicTalksViewModel : LocalViewModelBase, IViewModel
    {
        public PublicTalksViewModel(DatabaseContext dbContext)
        {
        }
    }
}
