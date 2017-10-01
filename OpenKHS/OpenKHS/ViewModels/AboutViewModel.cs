
using System;

namespace OpenKHS.ViewModels
{
    class AboutViewModel : DialogViewModelBase
    {
        public string Content
        {
            get
            {
                return "OpenKHS" + Environment.NewLine +
                        "Created by David Savage" + Environment.NewLine +
                        "Email: david@savaged.info" + Environment.NewLine +
                        "Website: https://github.com/savaged/OpenKHS";
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
