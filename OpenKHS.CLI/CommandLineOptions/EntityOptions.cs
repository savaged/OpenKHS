using CommandLine;

namespace OpenKHS.CLI.CommandLineOptions
{
    abstract class EntityOptions 
    {
        [Option('c', "clmm", SetName = "clmm", HelpText = "ClmmSchedule (Christian Life And Ministry Meeting Schedule)")]
        public bool IsClmmSchedule { get; set; }

        [Option('m', "lcm", SetName = "lcm", HelpText = "LocalCongregationMember")]
        public bool IsLocalCongregationMember { get; set; }

        [Option('a', "assignment", SetName = "assignment", HelpText = "Assignment")]
        public bool IsAssignment { get; set; }

        [Option('t', "type", SetName = "type", HelpText = "AssignmentType")]
        public bool IsAssignmentType { get; set; }
    }
}