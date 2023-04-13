// using System;

// Random random = new Random();
// Console.CursorVisible = false;
// int height = Console.WindowHeight - 1;
// int width = Console.WindowWidth - 5;
// bool shouldExit = false;

// int playerX = 1;
// int playerY = 1;
// string layoutCaractere = "#";

// int countFood = 0;
// int countLife = 4;
// int countSpecial_1 = 0;

// int foodX = 0;
// int foodY = 0;

// string[] states = { "('-')", "(^-^)", "(X_X)", "(+_+)" };

// /*
// * @ => Bomba (Hit Kill);
// * + => Pontos;
// * & => Especial que gera 7 pontos;
// * * => Dobra a velocidade do usuário(Max: 5);
// */
// string[] foods = { "@", "+", "&", "*" };
// string[] postionsFood = { "1", "2", "3", "4", "5" };

// string player = states[0];

// int food = 0;

// InitializeGame();
// while (!shouldExit)
// {
//     Move();
// }

// void ShowFood(int count)
// {

//     for (int i = 0; i < postionsFood.Length; i++)
//     {
//         food = random.Next(0, foods.Length);
//         foodX = random.Next(1, width - player.Length);
//         foodY = random.Next(1, height - 1);

//         if ((postionsFood[i] == "new") && count == 1)
//         {
//             postionsFood[i] = $"{foodX}, {foodY}, {food}";
//             Console.SetCursorPosition(foodX, foodY);
//             Console.Write(foods[food]);
//         }
//         if (count == 5)
//         {
//             postionsFood[i] = $"{foodX}, {foodY}, {food}";
//             Console.SetCursorPosition(foodX, foodY);
//             Console.Write(foods[food]);
//         }
//     }
//     System.Threading.Thread.Sleep(300);
//     ChangePlayer(0);
// }

// void ChangePlayer(int type)
// {
//     player = states[type];
//     Console.SetCursorPosition(playerX, playerY);
//     Console.Write(player);
// }

// void Move()
// {
//     int lastX = playerX;
//     int lastY = playerY;

//     switch (Console.ReadKey(true).Key)
//     {
//         case ConsoleKey.UpArrow:
//             playerY--;
//             break;
//         case ConsoleKey.DownArrow:
//             playerY++;
//             break;
//         case ConsoleKey.LeftArrow:
//             if (countSpecial_1 > 0) playerX -= 3;
//             else playerX--;
//             break;
//         case ConsoleKey.RightArrow:
//             if (countSpecial_1 > 0) playerX += 3;
//             else playerX++;
//             break;
//         case ConsoleKey.Escape:
//             shouldExit = true;
//             break;
//     }

//     Console.SetCursorPosition(lastX, lastY);
//     for (int i = 0; i < player.Length; i++)
//     {
//         Console.Write(" ");
//     }

//     playerX = (playerX < 0) ? 0 : (playerX >= width ? width : playerX);
//     playerY = (playerY < 0) ? 0 : (playerY >= height ? height : playerY);

//     if (countSpecial_1 > 0)
//     {
//         countSpecial_1 -= 1;
//     }
//     Console.SetCursorPosition(playerX, playerY);
//     Console.Write(player);

//     if (
//         (playerX >= (Console.WindowWidth - 5)) ||
//         (playerY >= (Console.WindowHeight - 1) ||
//         (playerY == 0) || (playerX == 0))
//     )
//     {
//         Console.Clear();
//         Console.WriteLine("Console foi redimensionado. Programa encerrando.");
//         Environment.Exit(1);
//     }

//     Eating(playerX, playerY);
// }

// void InitializeGame()
// {
//     Console.Clear();
//     Builder();
//     ShowFood(5);
//     Console.SetCursorPosition(10, 0);
//     Console.Write($"[+]====> Vidas: {countLife} _;==[/]=>/][][][\\<=[\\]==;_ Pontos: {countFood} <====[+]");
//     Console.SetCursorPosition(1, 1);
//     Console.Write(player);
// }

// void Eating(int X, int Y)
// {
//     for (int x = 0; x < postionsFood.Length; x++)
//     {
//         int food_X = int.Parse(postionsFood[x].Split(",")[0]);
//         int food_Y = int.Parse(postionsFood[x].Split(",")[1]);

//         food_X = (food_X - 4);
//         if (
//             (food_X == X && food_Y == Y) ||
//             (food_X == X - 1 && food_Y == Y) ||
//             (food_X == X - 2 && food_Y == Y) ||
//             (food_X == X - 3 && food_Y == Y) ||
//             (food_X == X - 4 && food_Y == Y)
//             )
//         {
//             int food_Type = int.Parse(postionsFood[x].Split(",")[2]);

//             switch (food_Type)
//             {
//                 case 0:
//                     countLife -= 1;
//                     ChangePlayer(2);
//                     if (countLife <= 0)
//                     {
//                         System.Threading.Thread.Sleep(1000);
//                         Console.Clear();
//                         Console.WriteLine("\n[PAC] Você acaba de ser explodido, boa sorte na próxima!\n");
//                         Environment.Exit(1);
//                     }
//                     break;
//                 case 1:
//                     ChangePlayer(1);
//                     countFood += 1;
//                     break;
//                 case 2:
//                     ChangePlayer(1);
//                     countFood += 7;
//                     break;
//                 case 3:
//                     ChangePlayer(3);
//                     countSpecial_1 = 10;
//                     break;
//             }
//             Console.SetCursorPosition(10, 0);
//             Console.Write($"[+]====> Vidas: {countLife} _;==[/]=>/][][][\\<=[\\]==;_ Pontos: {countFood} <====[+]");
//             postionsFood[x] = "new";
//             ShowFood(1);
//         }
//     }
// }


// /*
// * NOTE: Estilização desnecessaria, adicionado pra ficar visualmente agradavel.
// */
// void Builder()
// {
//     for (int i = 0; i < (Console.WindowHeight - 1); i++)
//     {
//         Console.SetCursorPosition(0, i);
//         Console.WriteLine(layoutCaractere);
//     }
//     for (int i = 0; i < (Console.WindowWidth); i++)
//     {
//         Console.SetCursorPosition(i, 0);
//         Console.Write(layoutCaractere);
//     }
//     for (int i = 0; i < (Console.WindowWidth); i++)
//     {
//         Console.SetCursorPosition(i, Console.WindowHeight - 1);
//         Console.Write(layoutCaractere);
//     }
//     for (int i = 0; i < (Console.WindowHeight - 1); i++)
//     {
//         Console.SetCursorPosition(Console.WindowWidth - 1, i);
//         Console.WriteLine(layoutCaractere);
//     }
// }
