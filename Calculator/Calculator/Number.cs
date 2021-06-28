using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class Number : IPart
    {
        public Type Type { get; set; }
        public double Value { get; set; }
    }
}
