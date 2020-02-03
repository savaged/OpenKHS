namespace OpenKHS.Models
{
    public abstract class LookupEntry : ModelBase, ILookupEntry
    {
        private string _name;

        public static ILookupEntry Empty => NullLookup.Default;

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

    public class NullLookup : ILookupEntry
    {
        private NullLookup() 
        {
            Name = string.Empty;
        }

        public static ILookupEntry Default => new NullLookup();

        public string Name { get; }

        public int Id 
        {
             get => -1;
             set => _ = value;
        }
    }
}