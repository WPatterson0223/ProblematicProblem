using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {
        static Random rng = new Random();
        static bool cont = true;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        static void Main(string[] args)
        {
            string canParse;
            do
            {
                Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? Enter: 'yes' OR 'no': ");
                canParse = Console.ReadLine();
                cont = (canParse == "yes");
                Console.WriteLine();
                if (canParse != "yes" && canParse != "no")
                {
                    Console.WriteLine("That is not a valid response. Try again");
                    Console.WriteLine();
                }
            } while (canParse != "yes" && canParse != "no");
            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();
            bool parse;
            int userAge;
            do
            {
                Console.WriteLine();
                Console.Write("What is your age? ");
                parse = int.TryParse(Console.ReadLine(), out userAge);
                if (!parse)
                {
                    Console.WriteLine();
                    Console.WriteLine("This is not a valid age. Try again.");
                }
            } while (!parse);
            bool seeList;
            do
            {
                Console.WriteLine();
                Console.Write("Would you like to see the current list of activities? Enter: 'yes' OR 'no': ");
                canParse = Console.ReadLine();
                seeList = canParse == "yes";
                if (canParse != "yes" && canParse != "no")
                {
                    Console.WriteLine();
                    Console.WriteLine("That is not a valid response. Try again.");
                }
            } while (canParse != "yes" && canParse != "no");
            if (seeList)
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }
                bool addToList;
                do
                {
                    Console.WriteLine();
                    Console.Write("Would you like to add any activities before we generate one? Enter: 'yes' OR 'no': ");
                    Console.WriteLine();
                    canParse = Console.ReadLine();
                    addToList = canParse == "yes";
                    if (canParse != "yes" && canParse != "no")
                    {
                        Console.WriteLine();
                        Console.WriteLine("That is not a valid response. Try again.");
                    }
                } while (canParse != "yes" && canParse != "no");
                while (addToList)
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }
                    do
                    {
                        Console.WriteLine();
                        Console.WriteLine("Would you like to add more? Enter: 'yes' OR 'no': ");
                        canParse = Console.ReadLine();
                        addToList = canParse == "yes";
                        if (canParse != "yes" && canParse != "no")
                        {
                            Console.WriteLine();
                            Console.WriteLine("That is not a valid response. Try again.");
                            Console.WriteLine();
                        }
                    } while (canParse != "yes" && canParse != "no");
                }
            }

            while (cont)
            {
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    //Thread.Sleep(500);
                }
                Console.WriteLine();
                Console.Write("Choosing your random activity");
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    //Thread.Sleep(500);
                }
                Console.WriteLine();
                int randomNumber = rng.Next(activities.Count);
                string randomActivity = activities[randomNumber];
                do
                {
                    if (userAge < 21 && randomActivity == "Wine Tasting")
                    {
                        Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                        Console.WriteLine("Pick something else!");
                        activities.Remove(randomActivity);
                        randomNumber = rng.Next(activities.Count);
                        randomActivity = activities[randomNumber];
                    }
                    Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Enter 'no' to Keep OR 'yes' to Redo: ");
                    Console.WriteLine();
                    canParse = Console.ReadLine();
                    cont = canParse == "yes";
                    if (canParse != "yes" && canParse != "no")
                    {
                        Console.WriteLine();
                        Console.WriteLine("That is not a valid response. Try again.");
                        Console.WriteLine();
                    }
                } while (canParse != "yes" && canParse != "no");
            }
        }
    }
}