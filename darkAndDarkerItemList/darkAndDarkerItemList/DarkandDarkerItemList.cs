using static System.Console;
using System;
using System.Collections.Generic;

class DarkandDarkerItemList
{
    static void Main()
    {
        List<Tuple<string, string[]>> gameLogs = new List<Tuple<string, string[]>>(); // uses a tuple for searching or modifying values, will use item name for search written in string format

        WriteLine("Dark and Darker Item List Tool\n"); // uses item name, ask how many players, saves player names, then list or display items, after user can modify or change values

        while (true)
        {
            Write("Enter the item name: "); // name item
            string itemName = ReadLine();

            Write("Enter the number of players in the game: "); // number of players
            int playerCount;
            if (!int.TryParse(ReadLine(), out playerCount) || playerCount < 0)
            {
                WriteLine("Invalid number of players. Skipping entry...");
                continue;
            }

            string[] playerNames = new string[playerCount];
            for (int i = 0; i < playerCount; i++)
            {
                Write($"Enter name of player {i + 1}: ");
                playerNames[i] = ReadLine() ?? "Unknown Player";
            }

            gameLogs.Add(new Tuple<string, string[]>(itemName, playerNames));

            WriteLine();

            Write("Do you want to enter another game? (yes/no): ");
            string response = ReadLine()?.Trim().ToLower();
            if (response != "yes") break;
        }

        WriteLine("\nItem List:"); // list items in the game logs, uses to diaply in format
        foreach (var log in gameLogs)
        {
            WriteLine(log.Item1 + ": " + string.Join(", ", log.Item2));
        }

        while (true)
        {
            Write("\nEnter an item name to search or modify (or type 'exit' to quit): "); // search or modify by item name
            string searchItem = ReadLine()?.Trim();
            if (searchItem?.ToLower() == "exit") break;

            int entryIndex = -1;
            for (int i = 0; i < gameLogs.Count; i++)
            {
                if (gameLogs[i].Item1.Equals(searchItem, StringComparison.OrdinalIgnoreCase))
                {
                    entryIndex = i;
                    break;
                }
            }

            if (entryIndex == -1)
            {
                WriteLine("Item not found.");
                continue;
            }

            WriteLine("Found: " + gameLogs[entryIndex].Item1 + ": " + string.Join(", ", gameLogs[entryIndex].Item2)); // displays the searched found item

            Write("Do you want to modify this entry? (yes/no): ");
            string modify = ReadLine()?.Trim().ToLower();
            if (modify == "yes")
            {
                Write("Enter the new item name: ");
                string newItemName = ReadLine() ?? gameLogs[entryIndex].Item1;
                gameLogs[entryIndex] = new Tuple<string, string[]>(newItemName, gameLogs[entryIndex].Item2);
                WriteLine("Item name updated successfully.");
            }
        }
    }
}
