Console.Clear();
char[] message = "The quick brown fox jumps over the lazy dog.".ToCharArray();
Array.Reverse(message);

int letterCount = 0;

foreach (char letter in message)
{
    if (letter == 'o') letterCount++;
}

Console.WriteLine(new String(message));
Console.WriteLine($"'o' appears {letterCount} times.");
