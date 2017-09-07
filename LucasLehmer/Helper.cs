using System;
using System.Linq;

namespace LucasLehmer
{
    public class Helper
    {
        /// <summary> Convert a hex string to its binary equivalent </summary>
        /// <param name="hexString"></param>
        /// <returns>binString, no leading zeros</returns>
        public static string Hex2Bin(string hexString)
        {
            return Hex2Bin(hexString, false);
        }

        /// <summary> Convert a hex string to its binary equivalent </summary>
        /// <param name="hexString"></param>
        /// <param name="padLeadingZeros">Pads leading zeros</param>
        /// <returns>binString with optional leading zeros</returns>
        public static string Hex2Bin(string hexString, bool padLeadingZeros)
        {
            // Binary value of first hex char isn't leading zero padded unless explicitly stated (with padUpTo4LeadingZeros)
            string firstHexDigitInBinary = Convert.ToString(Convert.ToInt32(hexString[0].ToString(), 16), 2);
            if (padLeadingZeros)
            {
                firstHexDigitInBinary = firstHexDigitInBinary.PadLeft(4, '0');
            }
            string result =
                (firstHexDigitInBinary == "0" ? string.Empty : firstHexDigitInBinary) +     // If first digit is 0, return it as an empty string
                String.Join(
                String.Empty,                                                               // "Empty" separator
                hexString.Substring(1, hexString.Length-1)                                  // Work through all the subsequent hex digits
                .Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2)
                .PadLeft(4, '0')));                                                         // Zero Pad all subsequent digits
            return result;
        }

    }
}
