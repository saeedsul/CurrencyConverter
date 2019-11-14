namespace CurrencyConverter.Domain
{
    public interface ICurrency
    {
        decimal PoundToDollar(double amount);
        decimal PoundToAud (double amount);
        decimal PoundToEuro (double amount);
    }
}