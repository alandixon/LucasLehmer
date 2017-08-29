using System;

namespace LucasLehmer
{
    class Program
    {
        private static string[] args;
        private static Options options;

        static void Main(string[] args)
        {
            Program.args = args;
            Program.options = new Options();
            try
            {
                var isValid = CommandLine.Parser.Default.ParseArguments(args, options);
                if (isValid)
                {
                    AlgoRunner algoRunner = new AlgoRunner(options);
                    algoRunner.Run();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

    }
}
