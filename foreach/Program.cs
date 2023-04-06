Console.Clear();

string[] ids = { "B123", "C234", "A345", "C15", "B177", "G3003", "C235", "B179" };

foreach (string id in ids)
{
    if (id.StartsWith("B")) Console.WriteLine($"The name starts with 'B'! \nValue: {id}");
}