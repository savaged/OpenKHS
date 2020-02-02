namespace OpenKHS.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var core = new Core(args);
            core.Run();
        }
    }
}
