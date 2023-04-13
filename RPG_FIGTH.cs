// using System;

// Console.Clear();

// Boolean proceed = true;
// string next = "hero";
// int heroLife = 10;
// int mahouLife = 10;

// Random attack = new Random();

// do
// {
//     int attackSword = attack.Next(1, 10);
//     switch (next)
//     {
//         case "hero":
//             mahouLife -= attackSword;
//             Console.WriteLine($"[Attack - HERO] O Rei Demonio foi danificado e perdeu {attackSword} saúde e agora tem {mahouLife} de saúde.");

//             next = "mahou";
//             break;
//         case "mahou":
//             heroLife -= attackSword;
//             Console.WriteLine($"[Attack - Rei Demonio] Herói foi danificado e perdeu {attackSword} saúde e agora tem {heroLife} de saúde");

//             next = "hero";
//             break;
//         default:
//             break;
//     }

//     if (heroLife < 0)
//     {
//         Console.WriteLine($"[Wins] Reino Demoniaco acaba de dominar o mundo, o hero não foi capaz de defender!");
//         proceed = false;
//     }
//     if (mahouLife < 0)
//     {
//         Console.WriteLine($"[Wins] O Rei Demonio foi subjulgado pelo heroi!");
//         proceed = false;
//     }

// } while (proceed);