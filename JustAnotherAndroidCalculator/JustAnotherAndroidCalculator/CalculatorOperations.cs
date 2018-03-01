using System;
using System.Collections.Generic;
using System.Text;

namespace JustAnotherAndroidCalculator
{
    public static class CalculatorOperations
    {
        public static Func<double, double, double> Addition => (a, b) => a + b;
        public static Func<double, double, double> Subtraction => (a, b) => a - b;
        public static Func<double, double, double> Division => (a, b) => a / b;
        public static Func<double, double, double> Multiplication => (a, b) => a * b;
    }
}
