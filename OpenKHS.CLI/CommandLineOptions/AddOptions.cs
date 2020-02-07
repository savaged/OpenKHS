using CommandLine;

namespace OpenKHS.CLI.CommandLineOptions
{
    [Verb("add", HelpText = "Add specified entity (default is 'm' Assignee AKA Local Congregation Member)")]
    class AddOptions : EntityOptions
    {

    }
}