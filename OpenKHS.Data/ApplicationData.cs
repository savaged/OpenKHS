using System;
using System.IO;
using System.Linq;

namespace OpenKHS.Data
{
    static class ApplicationData
    {
        static ApplicationData()
        {
            ResourceLocation = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            ResourceLocation += "\\";
            if (!Directory.Exists(ResourceLocation + "OpenKHS"))
            {
                Directory.CreateDirectory(ResourceLocation + "OpenKHS");
            }
            ResourceLocation += "OpenKHS\\";
        }

        public static readonly bool IsRunningFromTest = 
            AppDomain.CurrentDomain.GetAssemblies().Any(a => a.FullName.StartsWith("Microsoft.VisualStudio.Test"));

        public static readonly string ResourceLocation;
    }
}
