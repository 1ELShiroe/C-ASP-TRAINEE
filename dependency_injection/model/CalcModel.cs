namespace Model;
public class Calc : ICalc
{
    public decimal Add(decimal x, decimal y)
    {
        return x + y;
    }

    public decimal Division(decimal x, decimal y)
    {
        return x / y;
    }

    public decimal Multiplication(decimal x, decimal y)
    {
        return x * y;
    }

    public decimal Subtraction(decimal x, decimal y)
    {
        return x - y;
    }

}