namespace OpenKHS.Models
{
    public abstract class Lookup : ModelBase, ILookup
    {
        private string _name;

        public Lookup()
        {
            _name = string.Empty;
        }

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }
    }

    public class NullLookup : ILookup
    {
        private NullLookup() 
        {
            Name = string.Empty;
        }

        public static NullLookup Empty => new NullLookup();

        public string Name { get; }

        public int Id 
        {
             get => -1;
             set => _ = value;
        }
    }
}