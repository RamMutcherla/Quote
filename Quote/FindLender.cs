using System;
using System.Collections.Generic;
using System.Linq;

namespace Quote
{
    public class FindLender : IFindLender
    {
        public List<Lender> GetAVailableLenders(List<string[]> listLenders, int loanAmount)
        {
            var lenders = new List<Lender>();

            foreach (var row in listLenders.Skip(1))
            {
                double rate = 0;
                double.TryParse(row[1], out rate);

                decimal available = 0;
                decimal.TryParse(row[2], out available);

                var lender = new Lender
                {
                    Name = row[0],
                    Rate = rate,
                    Available = available,
                };

                lenders.Add(lender);
            }

            return lenders.Where(x => x.Available > loanAmount).ToList();
        }

        public double FindRate(List<Lender> lenders)
        {
            if (lenders.Count() == 0)
            {
                return 0;
            }

            return lenders.Min(r => r.Rate);
        }
    }
}