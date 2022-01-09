using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw4.Exercise0;

public static class ParseData
{
    public static int IntParse(string value)
    {
        return int.TryParse(value, out var result) ? result : -1;
    }

    public static double DoubleParse(string value)
    {
        return double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out var result) ? result : -1;
    }
}
