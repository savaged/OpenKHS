using CommandLine;

namespace OpenKHS.CLI.CommandLineOptions
{
    [Verb("list", HelpText = "List specified entity (default is 'm' Assignee AKA Local Congregation Member)")]
    class ListOptions : EntityOptions
    {
        [Option('t', "type", SetName = "type", HelpText = "AssignmentType")]
        public bool IsAssignmentType { get; set; }

    }
}
