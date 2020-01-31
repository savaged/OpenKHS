using System.Linq;
using CommandLine;

namespace OpenKHS.CLI
{
    class CommandLineOptions
    {
        /// <summary>
        /// Work-around because I couldn't get Option to work with verbs
        /// </summary>
        /// <value></value>
        [Value(0)]
        public string Args { get; set; }
        public string Verb => Args?.Split(' ')?.FirstOrDefault();        
        public string Entity => Args?.Split(' ')?.LastOrDefault();
    }
}