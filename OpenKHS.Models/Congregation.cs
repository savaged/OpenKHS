namespace OpenKHS.Models
{
    public class Congregation : LookupEntry
    {
        public Congregation()
        {
            IsLocal = false;
        }

        public bool IsLocal { get; protected set; }
        
    }
}
