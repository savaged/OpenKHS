
using System.IO;

namespace OpenKHS.Interfaces
{
    public interface IDumpsJson
    {
        string JsonEncode();

        void Dump(FileStream outputFile);
    }
}
