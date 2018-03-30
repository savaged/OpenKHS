using System;
using GalaSoft.MvvmLight;

namespace OpenKHS.ViewModels
{
    class AboutDialogViewModel : ViewModelBase
    {
        public string Content
        {
            get
            {
                return "OpenKHS" + Environment.NewLine +
                        "Created by David Savage" + Environment.NewLine +
                        "Email: david@savaged.info" + Environment.NewLine +
                        "Website: https://github.com/savaged/OpenKHS" + Environment.NewLine + Environment.NewLine +
                        Environment.NewLine + "\"You received free, give free.\" (Mt 10:8b)" + Environment.NewLine +
                        Environment.NewLine + "\"But let all things take place decently and by arrangement.\" (1 Co 14:40)";
            }
        }

        public string VersionText
        {
            get
            {
                var v = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                return "OpenKHS v" + v.ToString();
            }
        }
    }
}
