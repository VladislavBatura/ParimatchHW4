using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw4.Exercise0.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class AgeValidatorAttribute : Attribute
{
    public int AgeMin { get; set; }
    public int AgeMax { get; set; }
}
