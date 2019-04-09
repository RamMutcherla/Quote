using System;
using System.Drawing.Text;

namespace Quote
{
    static class Program
    {
        static void Main(string[] args)
        {
            int numberOfMonths = 36;

            IReadFile readFile = new ReadFile(new SplitFile());
            IFindLender find = new FindLender();
            ICalculation cal = new Calculation();

            try
            {
                var returnResult = readFile.Read(@args[0]);

                int loanAmount = Int32.Parse(args[1]);

                if (loanAmount < 1000 || loanAmount > 15000)
                {
                    Console.WriteLine("Requested amount should be between £1000 and £15000.");
                    Console.ReadKey();
                    return;
                }

                if (loanAmount % 100 != 0)
                {
                    Console.WriteLine("Requested amount should be any £100 increment between £1000 and £15000.");
                    return;
                }

                // Get all available lenders for given amount
                var lenders = find.GetAVailableLenders(returnResult, loanAmount);

                if (lenders?.Count == 0)
                {
                    Console.WriteLine("System did not find any lender for given Amount.");
                    return;
                }

                // Find minimum rate lender
                var rate = find.FindRate(lenders);

                var paymentAmount = cal.Calculate(loanAmount, numberOfMonths, rate);
                var interesrRate = rate * 1200;

                Console.WriteLine(string.Format("Requested amount: £{0:0}", loanAmount));
                Console.WriteLine(string.Format("Rate: {0:0.0}%", interesrRate));
                Console.WriteLine(string.Format("Monthly repayment: £{0:0.00}", paymentAmount));
                Console.WriteLine(string.Format("Total repayment: £{0:0.00}", paymentAmount * numberOfMonths));

            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to find suitable lender, due to technical issue, Exception: {0}", ex.Message.ToString());
                throw;
            }
        }
    }
}