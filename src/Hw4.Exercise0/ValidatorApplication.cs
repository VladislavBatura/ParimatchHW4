using Common;

namespace Hw4.Exercise0;

public sealed class ValidatorApplication
{
    /// <summary>
    /// Runs application.
    /// </summary>
    public ReturnCode Run(string[] args)
    {
        if (args is null || args.Length < 3)
        {
            return ReturnCode.InvalidArgs;
        }

        var name = args[0];
        var age = ParseData.IntParse(args[1]);
        var weight = ParseData.DoubleParse(args[2]);

        var person = new Person(name, age, weight);

        // validate
        var validationResult = PersonValidator.Validate(person);

        // and log validation result
        Console.WriteLine("Person {0} validation result is: {1}", person, validationResult);

        return validationResult.IsValid ? ReturnCode.Success : ReturnCode.InvalidArgs;
    }
}
