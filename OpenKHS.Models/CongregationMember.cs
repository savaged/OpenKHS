namespace OpenKHS.Models
{
    public abstract class CongregationMember : Lookup
    {
    }

    public class NullCongregationMember : CongregationMember
    {
        public new int Id => Lookup.Empty.Id;

        public new string Name => Lookup.Empty.Name;
    }
}
