using System.Collections.Generic;

namespace Quote
{
    public interface IFindLender
    {
        List<Lender> GetAVailableLenders(List<string[]> listLenders, int loanAmount);

        double FindRate(List<Lender> lenders);
    }
}