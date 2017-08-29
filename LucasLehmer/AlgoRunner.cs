using System;
using System.Numerics;

namespace LucasLehmer
{
    public class AlgoRunner
    {
        private Options options;
        private readonly int Two = 2;

        public AlgoRunner(Options options)
        {
            this.options = options;
        }

        public void Run()
        {
            Console.WriteLine("Candidate prime = " + options.Prime);

            DateTime startTime = DateTime.Now;

            // Let Mp = (2^p) − 1 be the Mersenne number to test with p an odd prime
            BigInteger Mp = BigInteger.Pow(Two, options.Prime) - 1;

            // Define a sequence Si for all i ≥ 0
            BigInteger Si = new BigInteger(4);
            for (int i = 0; i < (options.Prime -2); i++)
            {
                //Si = BigInteger.ModPow(Si, Two, Mp) - 2;
                Si = ((Si * Si) - 2) % Mp;

                bool somethingPrinted = false;

                if (options.ShowLoopCount)
                {
                    Console.WriteLine("Loop:" + i);
                    somethingPrinted = true;
                }

                // https://stackoverflow.com/questions/14048476/biginteger-to-hex-decimal-octal-binary-strings/15447131#15447131
                if (options.showSiInHex)
                {
                    Console.WriteLine(" 0x" +Si.ToString("X"));
                    somethingPrinted = true;
                }

                if (options.showSiInDec)
                {
                    Console.WriteLine(" " + Si.ToString(""));
                    somethingPrinted = true;
                }

                //if (options.showSiInBin)
                //{
                //    somethingPrinted = true;
                //}

                if (somethingPrinted)
                {
                    Console.WriteLine();
                }

            }

            // Is S(p-2) ≡ 0 ?
            BigInteger remainder = Si % Mp;

            if (options.showRemainder)
            {
                Console.WriteLine("Remainder = " + remainder);
            }

            if (remainder == 0)
            {
                Console.WriteLine(string.Format("The Mersenne number {0} derived from the prime {1} is a Mersenne prime", Mp, options.Prime));
                if (options.showDigitCount)
                {
                    Console.WriteLine(string.Format("Mp has {0} digits", Mp.ToString().Length));
                }
            }
            else
            {
                Console.WriteLine(string.Format("The Mersenne number {0} derived from the prime {1} is not a Mersenne prime", Mp, options.Prime));
            }


            DateTime endTime = DateTime.Now;

            if (options.ShowTime)
            {
                TimeSpan timetaken = endTime - startTime;
                string timeTakenString = string.Format("{0} hour(s), {1} min(s), {2}.{3:000} sec(s)", timetaken.Hours, timetaken.Minutes, timetaken.Seconds, timetaken.Milliseconds);
                Console.WriteLine(timeTakenString);
            }
        }
    }
}
