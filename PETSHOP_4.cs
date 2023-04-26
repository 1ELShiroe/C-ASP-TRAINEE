string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";
string suggestedDonation = "";

decimal decimalDonation = 0.00m;
string[] searchingIcons = {"/", "-", "\\", "*"};

int maxPets = 8;
string? readResult;
string menuSelection = "";

string[,] ourAnimals = new string[maxPets, 7];

for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 45 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            suggestedDonation = "85.00";
            break;

        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "gus";
            suggestedDonation = "49.99";
            break;

        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "snow";
            suggestedDonation = "40.00";
            break;

        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "3";
            animalPhysicalDescription = "Medium sized, long hair, yellow, female, about 10 pounds. Uses litter box.";
            animalPersonalityDescription = "A people loving cat that likes to sit on your lap.";
            animalNickname = "Lion";
            suggestedDonation = "40.00";
            break;

        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            suggestedDonation = "";
            break;

    }

    ourAnimals[i, 0] = $"ID #:                  {animalID}";
    ourAnimals[i, 1] = $"Species:               {animalSpecies}";
    ourAnimals[i, 2] = $"Age:                   {animalAge}";
    ourAnimals[i, 3] = $"Nickname:              {animalNickname}";
    ourAnimals[i, 4] = $"Physical description:  {animalPhysicalDescription}";
    ourAnimals[i, 5] = $"Personality:           {animalPersonalityDescription}";

    if (!decimal.TryParse(suggestedDonation, out decimalDonation))
    {
        decimalDonation = 45.00m;
    }

    ourAnimals[i, 6] = $"Suggested Donation:    {suggestedDonation}";
}

do
{
    Console.Clear();

    Console.WriteLine("\nBem-vindo ao aplicativo Contoso PetFriends. As opções do menu principal são:\n");
    Console.WriteLine("[1] Liste todas as nossas informações atuais sobre animais de estimação");
    Console.WriteLine("[2] Exibir todos os cães com uma característica especificada");
    Console.WriteLine("\n[!] Digite seu número de seleção (ou digite Exit para sair do programa)");

    readResult = Console.ReadLine();
    if (readResult != null) menuSelection = readResult.ToLower();

    switch (menuSelection)
    {
        case "1":
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: " && ourAnimals[i, 0].Length > 23)
                {
                    Console.WriteLine();
                    for (int j = 0; j < 7; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                }
            }
            Console.WriteLine("\n\n[!] Pressione a tecla Enter para continuar");
            readResult = Console.ReadLine();

            break;

        case "2":

            string dogCharacteristic = "";
            while (dogCharacteristic == "")
            {
                Console.WriteLine("\n[!] Insira as características de um cão desejado para pesquisar:");
                readResult = Console.ReadLine();
                if (readResult != null) dogCharacteristic = readResult.ToLower().Trim();
            }

            bool noMatchesDog = true;
            string dogDescription = "";

            for (int i = 0; i < maxPets; i++)
            {
                bool dogMatch = true;

                if (ourAnimals[i, 1].Contains("dog"))
                {

                    if (dogMatch == true)
                    {
                        dogDescription = ourAnimals[i, 4] + "\n" + ourAnimals[i, 5];

                        if (dogDescription.Contains(dogCharacteristic))
                        {
                            Console.WriteLine($"\n[INFO] Foi encontrado um animal {ourAnimals[i, 3]} é compatível!");
                            Console.WriteLine(dogDescription);

                            noMatchesDog = false;
                        }
                    }
                }
            }

            if (noMatchesDog) Console.WriteLine($"[INFO] Não foi encontrado nenhum animal: {dogCharacteristic}");

            Console.WriteLine("\n\n[!] Pressione a tecla Enter para continuar");
            readResult = Console.ReadLine();

            break;

        default:
            break;
    }

} while (menuSelection != "exit");
