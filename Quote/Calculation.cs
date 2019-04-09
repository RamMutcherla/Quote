using System;

namespace Quote
{
    public class Calculation : ICalculation
    {
        public decimal Calculate(int loanAmount, int numberOfMonths, double rate)
        {
            // (Rate * LoanAmount) / (1 - (1 + Rate) ^ NumberOfPayments * -1))
            decimal payment = Convert.ToDecimal((rate * loanAmount) / (1 - Math.Pow(1 + rate, numberOfMonths * -1)));

            return payment;
        }
     }
}