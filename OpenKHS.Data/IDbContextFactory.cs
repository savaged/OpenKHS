using System.Threading.Tasks;

namespace OpenKHS.Data
{
    public interface IDbContextFactory
    {
        Task<OpenKHSContext> CreateAsync();
    }
}