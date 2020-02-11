namespace OpenKHS.Data
{
    public interface IDbContextFactory
    {
        OpenKHSContext Create();
    }
}