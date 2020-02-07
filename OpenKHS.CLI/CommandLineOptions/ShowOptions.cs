using CommandLine;

namespace OpenKHS.CLI.CommandLineOptions
{
    [Verb("show", HelpText = "Show specified entity (default is 'm' Assignee AKA Local Congregation Member)")]
    class ShowOptions : EntityOptions
    {

    }
}