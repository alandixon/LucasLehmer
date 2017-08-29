using CommandLine;
using CommandLine.Text;
using System.Text;

namespace LucasLehmer
{
    public class Options
    {
        [Option('p', "prime", Required = true, HelpText = "Prime to be processed.")]
        public int Prime { get; set; }

        [Option('t', "showTime", HelpText = "Show time taken")]
        public bool ShowTime { get; set; }

        [Option('l', "showLoopCount", HelpText = "Show loop count")]
        public bool ShowLoopCount { get; set; }

        [Option('x', "showSiInHex", HelpText = "Show Si in hex")]
        public bool showSiInHex { get; set; }

        [Option('d', "showSiInDec", HelpText = "Show Si in decimal")]
        public bool showSiInDec { get; set; }

        [Option('r', "showRemainder", HelpText = "Show final remainder")]
        public bool showRemainder { get; set; }

        //[Option('b', "showSiInBin", HelpText = "Show Si in binary")]
        //public bool showSiInBin { get; set; }

        [Option('g', "showDigitCount", HelpText = "Show Mp digit count")]
        public bool showDigitCount { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            var usage = new StringBuilder();


            var helpText = HelpText.AutoBuild(this);
            usage.AppendLine(helpText.ToString());

            return usage.ToString();
        }

    }
}
