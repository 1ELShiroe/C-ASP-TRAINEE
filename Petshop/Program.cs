using System;

string animalSpecies = "", animalID = "", animalAge = "";
string animalPhysicalDescription = "", animalPersonalityDescription = "", animalNickname = "";
string idSearch = "", nameSearch = "", specieSearch = "", ageSearch = "", descriptionSearch = "", personSearch = "";

int maxPets = 8;
string? readResult;
string menuSelection = "";

string[,] ourAnimals = new string[maxPets, 6];

for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "Golden Retriever fêmea de tamanho médio, de cor creme, pesando cerca de 65 libras. domesticado.";
            animalPersonalityDescription = "Adora que acariciem a barriga e gosta de correr atrás do rabo. dá muitos beijos.";
            animalNickname = "lola";
            break;

        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "Grande Golden retriever macho marrom-avermelhado pesando cerca de 85 libras. domesticado.";
            animalPersonalityDescription = "adora receber carinho nas orelhas quando recebe você na porta, ou a qualquer hora! adora se inclinar e dar abraços caninos.";
            animalNickname = "loki";
            break;

        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "Pequena fêmea branca pesando cerca de 8 quilos. caixa de areia treinada.";
            animalPersonalityDescription = "Amigável";
            animalNickname = "Puss";
            break;

        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "?";
            animalPhysicalDescription = "?";
            animalPersonalityDescription = "?";
            animalNickname = "?";
            break;

        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;

    }

    ourAnimals[i, 0] = $"ID #:              {animalID}";
    ourAnimals[i, 1] = $"Espécies:          {animalSpecies}";
    ourAnimals[i, 2] = $"Idade:             {animalAge}";
    ourAnimals[i, 3] = $"Nome:              {animalNickname}";
    ourAnimals[i, 4] = $"Descrição física:  {animalPhysicalDescription}";
    ourAnimals[i, 5] = $"Personalidade:     {animalPersonalityDescription}";
}

do
{
    /*
    * Mostrar lista de opções presente no menu inicial.
    */
    Console.Clear();

    Console.WriteLine("Bem-vindo ao aplicativo Contoso PetFriends. As opções do menu principal são:");
    Console.WriteLine("[1] Liste todas as nossas informações atuais sobre animais de estimação.");
    Console.WriteLine("[2] Adicione um novo amigo animal à matriz ourAnimals.");
    Console.WriteLine("[3] Certifique-se de que as idades dos animais e as descrições físicas estejam completas.");
    Console.WriteLine("[4] Certifique-se de que os apelidos dos animais e as descrições de personalidade estejam completos.");
    Console.WriteLine("[5] Editar a idade de um animal.");
    Console.WriteLine("[6] Editar a descrição da personalidade de um animal.");
    Console.WriteLine("[7] Exibe todos os gatos com uma característica especificada.");
    Console.WriteLine("[8] Exibir todos os cães com uma característica especificada");
    Console.WriteLine("\n[INFO] Digite seu número de seleção (ou digite Exit para sair do programa):  ");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
        /*
        *   NOTA: Poderíamos colocar uma instrução do em torno da entrada menuSelection para garantir uma entrada válida, mas
        *   usa uma instrução condicional abaixo que processa apenas os valores de entrada válidos, portanto, a instrução do
        *   não é necessário aqui
        */
    }

    switch (menuSelection)
    {
        case "1":
            for (int i = 0; i < maxPets; i++)
            {
                /*
                *   Verificar a quantidade de formulários no sistema e filtrar os que estão completos e incompletos.
                *   Lista de todas informações de cada animal presente em nosso sistema.
                */
                if (ourAnimals[i, 0] != "ID #: " && ourAnimals[i, 0].Length > 19)
                {
                    Console.WriteLine();
                    for (int j = 0; j < 6; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                }
            }
            Console.WriteLine("\n[INFO] Pressione a tecla Enter para continuar.");
            readResult = Console.ReadLine();

            break;

        case "2":
            /*
            *   Adicione um novo amigo animal à matriz ourAnimals
            */
            string anotherPet = "y";
            int petCount = 0;
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    petCount += 1;
                }
            }

            if (petCount < maxPets)
            {
                Console.WriteLine($"No momento, temos {petCount} animais de estimação que precisam de um lar. Podemos gerenciar mais {(maxPets - petCount)}.");
            }

            while (anotherPet == "y" && petCount < maxPets)
            {
                bool validEntry = false;

                do
                {
                    Console.WriteLine("\n\rDigite 'cachorro' ou 'gato' para iniciar uma nova entrada");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalSpecies = readResult.ToLower();
                        if (animalSpecies != "dog" && animalSpecies != "cat")
                        {
                            Console.WriteLine($"Você entrou com: {animalSpecies}.");
                            validEntry = false;
                        }
                        else validEntry = true;
                    }
                } while (validEntry == false);

                /*
                *   Construa o número de identificação do animal
                *   EXEMPLO: C1, C2, D3 (Para Cat 1, Cat 2, Dog 3)
                */
                animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();

                do
                {
                    int petAge;
                    Console.WriteLine("Digite a idade do animal ou digite ? se desconhecido");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalAge = readResult;
                        if (animalAge != "?")
                        {
                            validEntry = int.TryParse(animalAge, out petAge);
                        }
                    }
                } while (validEntry == false);

                do
                {
                    Console.WriteLine("Insira uma descrição física do animal de estimação (tamanho, cor, sexo, peso, domesticado)");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalPhysicalDescription = readResult.ToLower();
                        if (animalPhysicalDescription == "")
                        {
                            animalPhysicalDescription = "tbd";
                        }
                    }
                } while (animalPhysicalDescription == "");

                do
                {
                    Console.WriteLine("[INFO] Digite uma descrição da personalidade do animal de estimação (gosta ou não, truques, nível de energia)");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalPersonalityDescription = readResult.ToLower();
                        if (animalPersonalityDescription == "")
                        {
                            animalPersonalityDescription = "tbd";
                        }
                    }
                } while (animalPersonalityDescription == "");

                do
                {
                    Console.WriteLine("[INFO] Entre com nome do animal: ");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalNickname = readResult.ToLower();
                        if (animalNickname == "")
                        {
                            animalNickname = "tbd";
                        }
                    }
                } while (animalNickname == "");

                // Armazene as informações do animal de estimação na matriz {ourAnimals} (Baseado em zero)

                ourAnimals[petCount, 0] = $"ID #:               {animalID}";
                ourAnimals[petCount, 1] = $"Especie:            {animalSpecies}";
                ourAnimals[petCount, 2] = $"Idade:              {animalAge}";
                ourAnimals[petCount, 3] = $"Nome:               {animalNickname}";
                ourAnimals[petCount, 4] = $"Descrição fisica:   {animalPhysicalDescription}";
                ourAnimals[petCount, 5] = $"Personalidade:      {animalPersonalityDescription}";

                // increment {petCount} (o array é baseado em zero, então incrementamos o contador depois de adicionar ao arra
                petCount = petCount + 1;

                if (petCount < maxPets)
                {
                    Console.WriteLine("Deseja inserir informações para outro animal de estimação (y/n)");
                    do
                    {
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            anotherPet = readResult.ToLower();
                        }

                    } while (anotherPet != "y" && anotherPet != "n");
                }
            }

            if (petCount >= maxPets)
            {
                Console.WriteLine("Atingimos nosso limite no número de animais de estimação que podemos gerenciar.");
                Console.WriteLine("\n[INFO] Pressione a tecla Enter para continuar.");
                readResult = Console.ReadLine();
            }

            break;

        case "3":
            Console.WriteLine("[!] Entre com a idade ou ID: ");
            readResult = Console.ReadLine();
            string? ageOrId = readResult?.ToLower();

            for (int i = 0; i < maxPets; i++)
            {
                if ((ourAnimals[i, 0] == $"ID #:              {ageOrId}") ||
                    (ourAnimals[i, 2] == $"Idade:             {ageOrId}"))
                {
                    idSearch = ourAnimals[i, 0];
                    specieSearch = ourAnimals[i, 1];
                    ageSearch = ourAnimals[i, 2];
                    nameSearch = ourAnimals[i, 3];
                    descriptionSearch = ourAnimals[i, 4];
                    personSearch = ourAnimals[i, 5];
                }
            }
            if (idSearch != "")
            {
                string message = "";
                string attSituation = "y";
                Console.WriteLine($"\n{idSearch}\n{nameSearch}\n{ageSearch}\n{specieSearch}\n{personSearch}\n{descriptionSearch}");
                if (ageSearch.Contains("?")) message = " | Idade";
                if (descriptionSearch.Contains("?")) message += " | Descrição |";
                if (message != "") Console.WriteLine($"\n[INFO] Informações incompletas: {message} \n[INFO] Deseja está atualizando? (y/n)");

                do
                {
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        attSituation = readResult.ToLower();
                    }

                } while (attSituation != "y" && attSituation != "n");


                if (descriptionSearch.Contains("?") && attSituation == "y")
                {
                    Console.WriteLine($"Insira uma descrição física para ID #: {ageOrId} (tamanho, cor, raça, sexo, peso, domesticado)");
                    readResult = Console.ReadLine();
                    if (readResult != null) descriptionSearch = readResult.ToLower();
                }
                if (ageSearch.Contains("?") && attSituation == "y")
                {
                    Console.WriteLine($"Insira a idade do animal para ID #: {ageOrId}");
                    readResult = Console.ReadLine();
                    if (readResult != null) ageSearch = readResult.ToLower();
                }
                Console.WriteLine($"Idade: {ageSearch}");
                Console.WriteLine($"Descrição: {descriptionSearch}");
                Console.WriteLine($"\n[INFO] Deseja prosseguir com a atualização? (y/n)");

                do
                {
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        attSituation = readResult.ToLower();
                    }

                } while (attSituation != "y" && attSituation != "n");
                if (attSituation == "y") Console.WriteLine($"\n[INFO] Atualização realizada com sucesso!");
                if (attSituation == "n") Console.WriteLine($"\n[INFO] Atualização cancelada sucesso!");
            }

            else
            {
                Console.WriteLine($"\n[INFO] Nenhum animal foi encontrado no sistema com ID/Idade: {ageOrId}");
            }
            Console.WriteLine("[INFO] Pressione a tecla Enter para continuar.");
            readResult = Console.ReadLine();
            break;

        case "4":
            Console.WriteLine("[!] Entre com a idade ou ID: ");
            readResult = Console.ReadLine();
            string? nameOrId = readResult?.ToLower();

            for (int i = 0; i < maxPets; i++)
            {
                if ((ourAnimals[i, 0] == $"ID #:              {nameOrId}") ||
                    (ourAnimals[i, 2] == $"Nome:              {nameOrId}"))
                {
                    idSearch = ourAnimals[i, 0];
                    specieSearch = ourAnimals[i, 1];
                    ageSearch = ourAnimals[i, 2];
                    nameSearch = ourAnimals[i, 3];
                    descriptionSearch = ourAnimals[i, 4];
                    personSearch = ourAnimals[i, 5];
                }
            }
            if (idSearch != "")
            {
                string message = "";
                string attSituation = "y";
                Console.WriteLine($"\n{idSearch}\n{nameSearch}\n{ageSearch}\n{specieSearch}\n{personSearch}\n{descriptionSearch}");
                if (ageSearch.Contains("?")) message = " | Nome";
                if (descriptionSearch.Contains("?")) message += " | Descrição de personalidade |";
                if (message != "") Console.WriteLine($"\n[INFO] Informações incompletas: {message} \n[INFO] Deseja está atualizando? (y/n)");

                do
                {
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        attSituation = readResult.ToLower();
                    }

                } while (attSituation != "y" && attSituation != "n");


                if (descriptionSearch.Contains("?") && attSituation == "y")
                {
                    Console.WriteLine($"Insira uma descrição de personalidade para ID #: {nameOrId} (tamanho, cor, raça, sexo, peso, domesticado)");
                    readResult = Console.ReadLine();
                    if (readResult != null) personSearch = readResult.ToLower();
                }
                if (ageSearch.Contains("?") && attSituation == "y")
                {
                    Console.WriteLine($"Insira o nome do animal para ID #: {nameOrId}");
                    readResult = Console.ReadLine();
                    if (readResult != null) nameSearch = readResult.ToLower();
                }
                Console.WriteLine($"Nome: {nameSearch}");
                Console.WriteLine($"Descrição: {personSearch}");
                Console.WriteLine($"\n[INFO] Deseja prosseguir com a atualização? (y/n)");

                do
                {
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        attSituation = readResult.ToLower();
                    }

                } while (attSituation != "y" && attSituation != "n");
                if (attSituation == "y") Console.WriteLine($"\n[INFO] Atualização realizada com sucesso!");
                if (attSituation == "n") Console.WriteLine($"\n[INFO] Atualização cancelada sucesso!");
            }

            else
            {
                Console.WriteLine($"\n[INFO] Nenhum animal foi encontrado no sistema com ID/Nome: {nameOrId}");
            }
            Console.WriteLine("[INFO] Pressione a tecla Enter para continuar.");
            readResult = Console.ReadLine();
            break;

        case "5":
            Console.WriteLine("EM CONSTRUÇÃO - volte no próximo mês para ver o progresso.");
            Console.WriteLine("\n[INFO] Pressione a tecla Enter para continuar.");
            readResult = Console.ReadLine();
            break;

        case "6":
            Console.WriteLine("EM CONSTRUÇÃO - volte no próximo mês para ver o progresso.");
            Console.WriteLine("\n[INFO] Pressione a tecla Enter para continuar.");
            readResult = Console.ReadLine();
            break;

        case "7":
            Console.WriteLine("EM CONSTRUÇÃO - volte no próximo mês para ver o progresso.");
            Console.WriteLine("\n[INFO] Pressione a tecla Enter para continuar.");
            readResult = Console.ReadLine();
            break;

        case "8":
            Console.WriteLine("EM CONSTRUÇÃO - volte no próximo mês para ver o progresso.");
            Console.WriteLine("\n[INFO] Pressione a tecla Enter para continuar.");
            readResult = Console.ReadLine();
            break;

        default:
            break;
    }

} while (menuSelection != "exit");