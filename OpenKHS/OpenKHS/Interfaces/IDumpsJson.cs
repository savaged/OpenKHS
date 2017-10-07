
using System.IO;

namespace OpenKHS.Interfaces
{
    public interface IDumpsJson
    {
        void Dump(FileStream outputFile);
    }
}
