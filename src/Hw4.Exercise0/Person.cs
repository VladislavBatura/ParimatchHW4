using Hw4.Exercise0.Attributes;

namespace Hw4.Exercise0;

public sealed class Person
{
    [NameValidator(Lenght = 1)]
    public string Name { get; set; }
    [AgeValidator(AgeMin = 18, AgeMax = 200)]
    public int Age { get; set; }
    [WeightValidator(WeightMin = 30, WeightMax = 200)]
    public double Weight { get; set; }

    public Person(string name, int age, double weight)
    {
        Name = name;
        Age = age;
        Weight = weight;
    }

    // create a validation attribute for properties
}
