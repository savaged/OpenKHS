using CommandLine;

namespace OpenKHS.CLI.CommandLineOptions
{
    [Verb("list", HelpText = "List the database entity specified.")]
    class ListOptions : EntityOptions
    {
    }
}