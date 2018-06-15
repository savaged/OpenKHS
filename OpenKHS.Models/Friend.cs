using System;
using OpenKHS.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace OpenKHS.Models
{
    public class Friend : ModelBase, IFriend
    {
        public Friend() { }

        [Required]
        public override string Name
        {
            get => base.Name;
            set => base.Name = value;
        }

        public virtual string Congregation { get; set; }
    }
}
