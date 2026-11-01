
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // Dictionary stores programming terms and their definitions.
    static Dictionary<string, List<string>> programmingDictionary =
        new Dictionary<string, List<string>>();

    static void Main()
    {
        PopulateDictionary();

        bool running = true;

        while (running)
        {
            Console.WriteLine("\n===== GROUP 6 DICTIONARY PROJECT =====");
            Console.WriteLine("1. Display Dictionary");
            Console.WriteLine("2. Remove a Key");
            Console.WriteLine("3. Add a New Key and Value");
            Console.WriteLine("4. Add a Value to an Existing Key");
            Console.WriteLine("5. Display Sorted Keys");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            // Switch statement controls the menu options.
            switch (choice)
            {
                case "1":
                    DisplayDictionary();
                    break;

                case "2":
                    RemoveKey();
                    break;

                case "3":
                    AddNewKey();
                    break;

                case "4":
                    AddValueToExistingKey();
                    break;

                case "5":
                    SortKeys();
                    break;

                case "6":
                    running = false;
                    Console.WriteLine("Thank you for using the dictionary!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    // Adds sample programming terms to the dictionary.
    static void PopulateDictionary()
    {
        programmingDictionary.Add("Class",
            new List<string> { "A blueprint used to create objects." });

        programmingDictionary.Add("Object",
            new List<string> { "An instance of a class." });

        programmingDictionary.Add("Method",
            new List<string> { "A block of code that performs a task." });

        programmingDictionary.Add("Dictionary",
            new List<string> { "A collection that stores key-value pairs." });
    }

    // Displays dictionary contents using foreach enumeration.
    static void DisplayDictionary()
    {
        Console.WriteLine("\n--- Programming Dictionary ---");

        if (programmingDictionary.Count == 0)
        {
            Console.WriteLine("The dictionary is empty.");
            return;
        }

        foreach (var item in programmingDictionary)
        {
            Console.WriteLine(item.Key + ":");

            foreach (string definition in item.Value)
            {
                Console.WriteLine(" - " + definition);
            }
        }
    }

    // Removes a key selected by the user.
    static void RemoveKey()
    {
        Console.Write("Enter the programming term to remove: ");
        string key = Console.ReadLine();

        if (programmingDictionary.Remove(key))
        {
            Console.WriteLine("Term removed successfully.");
        }
        else
        {
            Console.WriteLine("Term was not found.");
        }
    }

    // Adds a new key and its definition.
    static void AddNewKey()
    {
        Console.Write("Enter a new programming term: ");
        string key = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(key))
        {
            Console.WriteLine("Term cannot be empty.");
            return;
        }

        if (programmingDictionary.ContainsKey(key))
        {
            Console.WriteLine("That term already exists.");
            return;
        }

        Console.Write("Enter its definition: ");
        string definition = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(definition))
        {
            Console.WriteLine("Definition cannot be empty.");
            return;
        }

        programmingDictionary.Add(key,
            new List<string> { definition });

        Console.WriteLine("New term added successfully.");
    }

    // Adds another definition to an existing key.
    static void AddValueToExistingKey()
    {
        Console.Write("Enter an existing programming term: ");
        string key = Console.ReadLine();

        if (programmingDictionary.ContainsKey(key))
        {
            Console.Write("Enter an additional definition: ");
            string definition = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(definition))
            {
                Console.WriteLine("Definition cannot be empty.");
                return;
            }

            programmingDictionary[key].Add(definition);
            Console.WriteLine("Definition added successfully.");
        }
        else
        {
            Console.WriteLine("Term was not found.");
        }
    }

    // Sorts and displays dictionary keys alphabetically.
    static void SortKeys()
    {
        Console.WriteLine("\n--- Dictionary Keys (Alphabetical) ---");

        List<string> sortedKeys =
            programmingDictionary.Keys.OrderBy(key => key).ToList();

        foreach (string key in sortedKeys)
        {
            Console.WriteLine(key);
        }
    }
}
