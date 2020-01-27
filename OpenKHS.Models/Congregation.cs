namespace OpenKHS.Models
{
    public class Congregation : Lookup
    {
        public Congregation()
        {
            IsLocal = false;
        }

        public bool IsLocal { get; protected set; }
        
    }
}
