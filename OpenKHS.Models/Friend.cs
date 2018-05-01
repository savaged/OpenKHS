using System;
using OpenKHS.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace OpenKHS.Models
{
    public class Friend : ModelBase, IFriend
    {
        private string _name;

        public Friend() { }

        [Required]
        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }
    }
}
