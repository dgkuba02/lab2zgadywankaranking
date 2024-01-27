    using System;
    using System.IO;
    using System.Collections.Generic;

    Random rnd = new Random();
    int x = 0;
    int tries = 0;
    bool found = false;
    
    string filePath ="/Users/jakubkoprowski/Desktop/wsb/pppdz/zgadywankawyniki/zgadywankaranking/ranking.txt";
    List<string> linesList = new List<string>(File.ReadAllLines(filePath));

    Console.WriteLine("Witaj w zgadywance liczby od 1 do 100.\nGra wylosowała liczbę, zgadnij ją w max. 10 próbach, powodzenia!");

    x = rnd.Next(1, 100);

    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine("Wpisz liczbę");
        int z = Convert.ToInt32(Console.ReadLine());
        if (z == x)
        {
            tries++;
            found = true;
            break;
        }
        else
        {
            tries++;
            if(z > x)
            {
                Console.WriteLine("Podana liczba jest większa od wylosowanej.");
            }
            else
            {
                Console.WriteLine("Podana liczba jest mniejsza od wylosowanej.");
            }
        }
    }

    Console.Clear();

    if(found)
    {
        
        Console.WriteLine("Brawo! Wylosowana liczba to " + Convert.ToString(x) + ". Liczba została odgadnięta w " + Convert.ToString(tries) + " próbach.");
        Console.WriteLine("Podaj swój nick:");
        
        string playerName = " " + Console.ReadLine();

        linesList.Add(Convert.ToString(tries) +  playerName);
        linesList.Sort();
        File.WriteAllLines(filePath, linesList);
        int position = linesList.IndexOf(Convert.ToString(tries));
    }
    else
    {
        Console.WriteLine("Niestety nie udało Ci się odgadnąć wylosowanej liczby.");
    }

    Console.WriteLine("Ranking (ilość prób):");
    Console.WriteLine(String.Join(Environment.NewLine, linesList.Select((x, n) => $"{n + 1}. {x}")));
    
