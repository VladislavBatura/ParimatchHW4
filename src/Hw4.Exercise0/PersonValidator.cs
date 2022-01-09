using Hw4.Exercise0.Attributes;

namespace Hw4.Exercise0;

public static class PersonValidator
{
    public static PersonValidationResult Validate(Person? person)
    {
        if (person is null)
        {
            return new PersonValidationResult
            {
                ErrorMessage = "Person can't be null",
                IsValid = false
            };
        }

        var nameValid = Validator.NameValidate(person);
        var ageValid = Validator.AgeValidate(person);
        var weightValid = Validator.WeightValidate(person);

        return nameValid && ageValid && weightValid
            ? new PersonValidationResult
            {
                IsValid = true
            }
            : !nameValid
                ? new PersonValidationResult
                {
                    ErrorMessage = "Person Name is required",
                    IsValid = false
                }
                : !ageValid
                    ? new PersonValidationResult
                    {
                        ErrorMessage = $"Person Age is out of range",
                        IsValid = false
                    }
                    : new PersonValidationResult
                    {
                        ErrorMessage = $"Person Weight is out of range",
                        IsValid = false
                    };
    }
}
