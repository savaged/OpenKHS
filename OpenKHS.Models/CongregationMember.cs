namespace OpenKHS.Models
{
    public abstract class CongregationMember : Lookup
    {
    }

    public class NullCongregationMember : CongregationMember
    {
        public new int Id => NullLookup.Empty.Id;

        public new string Name => NullLookup.Empty.Name;
    }
}
