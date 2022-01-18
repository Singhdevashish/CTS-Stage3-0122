using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculatorApp
{
    public class TaxCalculator
    {
        public double CalculateTaxAmount(double annualIncome)
        {
            if (annualIncome <= 0)
                throw new ArgumentException("Invalid annual income");

            double TaxPayable = 0;
            if (annualIncome >= 200000 && annualIncome < 300000)
                TaxPayable = annualIncome * 0.02;
            else if (annualIncome >= 300000 && annualIncome < 500000)
                TaxPayable = annualIncome * 0.05;
            else
                TaxPayable = annualIncome * 0.08;
            return TaxPayable;
        }
    }
}
