using CommandLine;

namespace OpenKHS.CLI
{
    class CommandLineOptions
    {
        [Option('a', "action", HelpText = "The action to perform")]
        public string Action { get; set; }

        [Option('s', "subject", HelpText = "The subject upon which an action is performed")]
        public string Subject { get; set; }
    }
}