using System.Reflection;
using Hw4.Exercise0.Attributes;

namespace Hw4.Exercise0;

public static class Validator
{
    public static bool NameValidate(Person target)
    {
        var type = target.GetType();
        var attribute = type.GetProperty(nameof(target.Name))!.GetCustomAttribute<NameValidatorAttribute>();

        if (IsNullOrEmpty(target.Name))
            return false;

        return attribute?.Lenght is not null && target.Name.Length >= attribute.Lenght;
    }

    public static bool AgeValidate(Person target)
    {
        var type = target.GetType();
        var attribute = type.GetProperty(nameof(target.Age))!.GetCustomAttribute<AgeValidatorAttribute>();

        if (IsNullOrEmpty(target.Age))
            return false;

        return attribute?.AgeMin is not null && attribute?.AgeMax is not null
            && target.Age >= attribute.AgeMin && target.Age <= attribute.AgeMax;
    }

    public static bool WeightValidate(Person target)
    {
        var type = target.GetType();
        var attribute = type.GetProperty(nameof(target.Weight))!.GetCustomAttribute<WeightValidatorAttribute>();

        if (IsNullOrEmpty(target.Weight))
            return false;

        return attribute?.WeightMin is not null && attribute?.WeightMax is not null
            && target.Weight >= attribute.WeightMin && target.Weight <= attribute.WeightMax;
    }

    private static bool IsNullOrEmpty(string val)
    {
        if (string.IsNullOrWhiteSpace(val))
        {
            return true;
        }
        else if (string.IsNullOrWhiteSpace(val))
        {
            return true;
        }
        return false;
    }

    private static bool IsNullOrEmpty(int value)
    {
        return value == 0;
    }

    private static bool IsNullOrEmpty(double value)
    {
        return value < 1;
    }
}
