using CommandLine;

namespace OpenKHS.CLI.CommandLineOptions
{
    abstract class EntityOptions 
    {
        [Option('c', "clmm", SetName = "clmm", HelpText = "ClmmSchedule (Christian Life And Ministry Meeting Schedule)")]
        public bool IsClmmSchedule { get; set; }

        [Option('p', "pm", SetName = "pm", HelpText = "PmSchedule (Public Meeting Schedule)")]
        public bool IsPmSchedule { get; set; }

        [Option('m', "assignee", SetName = "assignee", HelpText = "Assignee (Congregation Member)")]
        public bool IsAssignee { get; set; }

        [Option('a', "assignment", SetName = "assignment", HelpText = "Assignment")]
        public bool IsAssignment { get; set; }

    }
}
