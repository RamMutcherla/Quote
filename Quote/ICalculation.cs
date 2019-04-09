namespace Quote
{
    public interface ICalculation
    {
        decimal Calculate(int loanAmount, int numberOfMonths, double rate);
    }
}