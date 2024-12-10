using System.Xml.Linq;

internal class Program
{
    private static Dictionary<string, int> _ranking = new Dictionary<string, int>();

    private static void Main(string[] args)
    {
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

            switch (choice)
            {
                case "1":
                    ShowRanking();
                    break;
                 case "2":
                    ShowScore();
                    break;
                case "3":
                    AddOrUpdate();
                    break;
                case "4":
                    ShowAverage();
                    break;
                case "5":
                    ShowHighest();
                    break;
                case "6":
                    keepRunning = false;
                    break;
            }

            //} while (keepRunning == true);
        } while (keepRunning);
    }

    private static void ShowRanking()
    {
        //foreach(var pair in _ranking) 
        //{
        //    Console.WriteLine($"{pair.Key}: {pair.Value}");
        //}

        foreach (string name in _ranking.Keys)
        {
            int score = _ranking[name];
            Console.WriteLine($"{name}:\t {score}");
        }

        Console.ReadKey();
    }

    private static void ShowScore()
    {
        Console.Write("Naam: ");
        string name = Console.ReadLine();

        if(_ranking.TryGetValue(name, out int score))
        {
            Console.WriteLine($"De score van {name} is {score}");
        }
        else
        {
            Console.WriteLine($"{name} niet gevonden in klassement.");
        }

        Console.ReadKey();
    }

    private static void AddOrUpdate()
    {
        Console.Write("Naam: ");
        string name = Console.ReadLine();
        Console.Write("Punten: ");
        string score = Console.ReadLine();


        if (!_ranking.ContainsKey(name))
        {
            _ranking.Add(name, int.Parse(score));
            Console.WriteLine($"{name} werd toegevoegd.");
        }
        else
        {
            _ranking[name] = int.Parse(score);
            Console.WriteLine($"{name} werd gewijzigd.");
        }

        Console.ReadKey(true);
    }

    private static void ShowAverage()
    {
        double sum = 0;

        foreach (int score in _ranking.Values)
        {
            sum += score;
        }

        double average = sum / _ranking.Values.Count;
        Console.WriteLine($"De gemiddelde score is {average}.");

        Console.ReadKey();
    }

    private static void ShowHighest()
    {
        KeyValuePair<string, int> highest = _ranking.MaxBy(s => s.Value);
        Console.WriteLine($"{highest.Key} heeft {highest.Value} punten.");

        //string highest = _ranking.Keys.First();
        //foreach(string name in _ranking.Keys)
        //{
        //    if (_ranking[name] > _ranking[highest])
        //    {
        //        highest = name;
        //    }
        //}

        //Console.WriteLine($"{highest} heeft {_ranking[highest]} punten.");


        Console.ReadKey();
    }
}