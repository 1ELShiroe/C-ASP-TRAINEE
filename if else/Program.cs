Console.Clear();

Random random = new Random();
int daysUntilExpiration = random.Next(12);
int discountPercentage = 0;

if (daysUntilExpiration <= 10)
{
    if (daysUntilExpiration == 0) Console.WriteLine("Your subscription has expired.");
    else if (daysUntilExpiration == 1)
    {
        Console.WriteLine("Your subscription expires within a day!");
        Console.WriteLine("Renew now and save 20%!");
        discountPercentage += 20;
    }
    else if (daysUntilExpiration <= 5)
    {
        Console.WriteLine($"Your subscription expires in {daysUntilExpiration} days.");
        Console.WriteLine("Renew now and save 10%!");
        discountPercentage += 10;
    }
    else Console.WriteLine("Your subscription will expire soon. Renew now!");
}