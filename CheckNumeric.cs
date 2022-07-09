using System;
using System.Collections.Generic;
using System.Text;

namespace Calculation2.Settings
{
    class CheckNumeric
    {
        public static bool Numeric { get; set; }

        public static int TestedNumber { get; set; }

        public static void TestNumber(string a)
        {
            Numeric = Int32.TryParse(a, out int i);
            TestedNumber = i;
        }
    }
}
