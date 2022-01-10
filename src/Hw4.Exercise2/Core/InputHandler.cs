
using Hw4.Exercise2.Models;

namespace Hw4.Exercise2.Core;

public static class InputHandler
{
    public static int IntTryParse(string arg)
    {
        return int.TryParse(arg, out var result) ? result : -1;
    }

    public static InputModel ReturnModel(string[] args)
    {
        if (args.Length == 1)
        {
            return new InputModel(args[0]);
        }
        if (args.Length == 2)
        {
            var step = IntTryParse(args[1]);
            if (step < 1)
            {
                return new InputModel(args[0]);
            }
            return new InputModel(args[0], step);
        }
        else
        {
            return new InputModel();
        }

        //var step = IntTryParse(args[1]);
        //if (step < 1 &&
        //    (string.IsNullOrEmpty(args[2])
        //    || !args[2].Equals("enc", StringComparison.Ordinal)
        //    || !args[2].Equals("desc", StringComparison.Ordinal)))
        //{
        //    return new InputModel(args[0]);
        //}
        //else if (step < 1)
        //{
        //    return new InputModel(args[0], args[2]);
        //}
        //else if (string.IsNullOrEmpty(args[2])
        //    || !args[2].Equals("enc", StringComparison.Ordinal)
        //    || !args[2].Equals("desc", StringComparison.Ordinal))
        //{
        //    return new InputModel(args[0], step);
        //}
        //else if (string.IsNullOrEmpty(args[0]))
        //{
        //    return new InputModel(step, args[2]);
        //}
        //else
        //{
        //    return new InputModel();
        //}
    }
}
