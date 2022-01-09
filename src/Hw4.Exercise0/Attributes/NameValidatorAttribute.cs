namespace Hw4.Exercise0.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class NameValidatorAttribute : Attribute
{
    public int Lenght { get; set; }

}
