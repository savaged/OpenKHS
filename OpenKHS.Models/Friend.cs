using System;
using System.ComponentModel.DataAnnotations;

namespace OpenKHS.Models
{
    public abstract class Friend : ModelBase
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
