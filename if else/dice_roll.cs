// Console.Clear();
// Random dice = new Random();

// int dice_one = dice.Next(1, 7);
// int dice_two = dice.Next(1, 7);
// int dice_three = dice.Next(1, 7);

// int value = dice_one + dice_two + dice_three;

// Console.WriteLine($"Dice roll: [{dice_one}] [{dice_two}] [{dice_three}]");

// if ((dice_one == dice_two) || (dice_two == dice_three) || (dice_three == dice_one))
// {
//     if ((dice_one == dice_two) && (dice_two == dice_three))
//     {
//         Console.WriteLine("You rolled triples! +6 bonus to total!");
//         value += 6;
//     }
//     else
//     {
//         Console.WriteLine("You rolled doubles! +2 bonus to total!");
//         value += 2;
//     }
// }
// if (value >= 16) Console.WriteLine("You win a new car!");
// else if (value >= 10) Console.WriteLine("You win a new laptop!");
// else if (value == 7) Console.WriteLine("You win a trip for two!");
// else Console.WriteLine("You win a kitten!");
// Console.WriteLine($"Dice all: {value}");