namespace Model;
public interface ICalc
{
    decimal Add(decimal x, decimal y);
    decimal Subtraction(decimal x, decimal y);
    decimal Multiplication(decimal x, decimal y);
    decimal Division(decimal x, decimal y);
}