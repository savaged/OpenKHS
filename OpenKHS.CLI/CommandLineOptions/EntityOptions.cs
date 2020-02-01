using CommandLine;

namespace OpenKHS.CLI.CommandLineOptions
{
    abstract class EntityOptions 
    {
        [Option('c', "clmm", HelpText = "ClmmSchedule (Christian Life And Ministry Meeting Schedule)")]
        public bool IsClmmSchedule { get; set; }

        [Option('l', "lcm", HelpText = "LocalCongregationMember")]
        public bool IsLocalCongregationMember { get; set; }

        [Option('a', "assignment", HelpText = "Assignment")]
        public bool IsAssignment { get; set; }

        [Option('t', "type", HelpText = "AssignmentType")]
        public bool IsAssignmentType { get; set; }
    }
}