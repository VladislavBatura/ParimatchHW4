using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw4.Exercise0.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class WeightValidatorAttribute : Attribute
    {
        public double WeightMin { get; set; }
        public double WeightMax { get; set; }
    }
}
