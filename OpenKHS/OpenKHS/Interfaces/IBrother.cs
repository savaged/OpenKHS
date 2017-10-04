
namespace OpenKHS.Interfaces
{
    public interface IBrother
    {
        string Firstname { get; set; }

        string Lastname { get; set; }

        string Mobile { get; set; }

        string Landline { get; set; }

        string Email { get; set; }

        bool Male { get; }
    }
}
