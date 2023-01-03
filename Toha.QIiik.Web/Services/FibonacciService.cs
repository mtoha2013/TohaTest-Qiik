using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toha.QIiik.Web.Interfaces;

namespace Toha.QIiik.Web.Services
{
    public class FibonacciService : IFibonacciService
    {
        public decimal CalculateFibonacci(int valueInputFibonacci)
        {
            decimal dResulr = 0;

            if (valueInputFibonacci <= 1)
                return valueInputFibonacci;

            decimal number1 = 0;
            decimal number2 = 1;
            decimal numberCurrent = 0;

            for (int i = 2; i <= valueInputFibonacci; i++) {
                numberCurrent = number1 + number2;
                number1 = number2;
                number2 = numberCurrent;
            }
            return numberCurrent;
        }
    }
}
