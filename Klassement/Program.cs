Dictionary<string, int> ranking = new Dictionary<string, int>();
bool keepRunning = true;

do
{
    Console.Clear();
    Console.WriteLine("Welkom bij het Klassement Beheer Systeem!");
    Console.WriteLine("Kies een optie uit het menu:");
    Console.WriteLine();
    Console.WriteLine("1. Toon het klassement");
    Console.WriteLine("2. Zoek de score van een deelnemer");
    Console.WriteLine("3. Pas de score van een deelnemer aan of voeg een nieuwe deelnemer toe");
    Console.WriteLine("4. Toon de gemiddelde score");
    Console.WriteLine("5. Toon de deelnemer met de hoogste score");
    Console.WriteLine("6. Stop het programma");
    Console.WriteLine();
    Console.Write("Maak uw keuze: ");

    string choice = Console.ReadLine();

    switch(choice)
    {
        case "3":
            Console.Write("Naam: ");
            string name = Console.ReadLine();
            Console.Write("Punten: ");
            string score = Console.ReadLine();


            if (!ranking.ContainsKey(name))
            {
                ranking.Add(name, int.Parse(score));
                Console.WriteLine($"{name} werd toegevoegd.");
            }
            else
            {
                ranking[name] = int.Parse(score);
                Console.WriteLine($"{name} werd gewijzigd.");
            }

            Console.ReadKey(true);
            break;
        case "6":
            keepRunning = false;
            break;
    }
//} while (keepRunning == true);
} while (keepRunning) ;