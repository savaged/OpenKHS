using CommandLine;

namespace OpenKHS.CLI.CommandLineOptions
{
    [Verb("list", HelpText = "List specified entity (default is 'lcm' Local Congregation Member)")]
    class ListOptions : EntityOptions
    {

    }
}