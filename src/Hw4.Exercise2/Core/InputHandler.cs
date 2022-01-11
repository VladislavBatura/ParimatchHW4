
using Hw4.Exercise2.Models;

namespace Hw4.Exercise2.Core;

public static class InputHandler
{
    public static int IntTryParse(string arg)
    {
        if (int.TryParse(arg, out var result))
        {
            if (result > 0)
            {
                return result;
            }
        }
        return -1;
    }
    public static string? ModeChecker(string arg)
    {
        if (arg.Equals("enc", StringComparison.Ordinal)
            || arg.Equals("dec", StringComparison.Ordinal))
        {
            return arg;
        }
        return null;
    }

    public static InputModel ReturnModel(string[] args)
    {
        int step;
        switch (args.Length)
        {
            case 0:
                return new InputModel();
            case 1:
                return new InputModel(args.First());
            case 2:
                step = IntTryParse(args[1]);
                return step != -1 ? new InputModel(args.First(), step) :
                    new InputModel(args.First());
            case 3:
                step = IntTryParse(args[1]);
                var mode = ModeChecker(args[2]);
                if (step != -1 && !string.IsNullOrEmpty(mode))
                {
                    return new InputModel(args.First(), step, mode);
                }
                else if (step != -1)
                {
                    if (string.IsNullOrEmpty(mode))
                    {
                        return new InputModel(args.First(), step);
                    }
                    return new InputModel(args.First(), step, mode);
                }
                else
                {
                    return new InputModel(args.First());
                }
            default:
                return new InputModel();
        }
    }
}
