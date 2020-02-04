using System.ComponentModel.DataAnnotations.Schema;

namespace OpenKHS.Models
{
    public abstract class LookupEntry : ModelBase, ILookupEntry
    {
        private string _name;

        public LookupEntry()
        {
            _name = string.Empty;
        }

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }
    }

    public class NullLookupEntry : ILookupEntry
    {
        private static readonly ILookupEntry _default = new NullLookupEntry();

        private NullLookupEntry() 
        {
            Name = string.Empty;
        }

        public static ILookupEntry Default => _default;

        public string Name { get; }

        public int Id 
        {
             get => -1;
             set => _ = value;
        }
    }
}