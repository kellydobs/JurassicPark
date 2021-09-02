using System;
using System.Collections.Generic;
using System.Linq;


namespace JurassicPark
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Jurassic Park!!");


            // Test code
            // DinosaurDatabase.Add("carnivore", "Godzilla", 328000000, 1);
            // DinosaurDatabase.Add("carnivore", "T-Rex", 13000, 1);
            // DinosaurDatabase.Add("carnivore", "Steve", 8000, 2);
            // DinosaurDatabase.Add("herbivore", "Sarah", 12500, 3);
            // DinosaurDatabase.Add("herbivore", "Buttons", 2, 100);

            // DinosaurDatabase.Remove("Godzilla");

            // DinosaurDatabase.Transfer("Buttons", 1000);

            // DinosaurDatabase.ViewDinos("Name");

            // DinosaurDatabase.ViewDinos("Enclosure");

            // DinosaurDatabase.Summary();

            bool keepGoing = true;
            string input = "";

            while (keepGoing)
            {
                Console.WriteLine("==============================================");
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("(A)dd a dino");
                Console.WriteLine("(R)emove a dino");
                Console.WriteLine("(T)ransfer a dino");
                Console.WriteLine("(S)ummerize the dinos");
                Console.WriteLine("(V)iew the dinos in specific order");
                Console.WriteLine("or (Q)uit?");

                input = Console.ReadLine().ToUpper();

                switch (input)
                {
                    case "A":
                        string newDiet = "";
                        string newName = "";
                        int newWeight = 0;
                        int newEnclosure = 0;

                        Console.Write("Is you dino a (H)erbivore or (C)arnivore?");
                        string response = Console.ReadLine().ToUpper();

                        if (response == "H")
                        {
                            newDiet = "herbivore";
                        }
                        else if (response == "C")
                        {
                            newDiet = "carnivore";
                        }
                        else
                        {
                            Console.WriteLine("Invalid diet type!");
                            break;

                        }


                        Console.Write("What is your new dino's name? ");
                        newName = Console.ReadLine();

                        Console.Write("What is the weight of your new dino in pounds? ");
                        newWeight = int.Parse(Console.ReadLine());

                        Console.Write($"Which # enclosure would you like to place {newName} in? ");
                        newEnclosure = int.Parse(Console.ReadLine());

                        DinosaurDatabase.Add(newDiet, newName, newWeight, newEnclosure);

                        break;

                    case "R":
                        Console.Write("What is the name of the dino you want to remove? ");
                        Dinosaur dinoBeingRemoved = DinosaurDatabase.Remove(Console.ReadLine());

                        if (dinoBeingRemoved != null)
                        {
                            Console.WriteLine($"{dinoBeingRemoved.Name} has been removed.");
                        }
                        else
                        {
                            Console.WriteLine("This dino does not exist!");
                        }
                        break;

                    case "T":
                        Console.Write("What is the name of the dino you want to transfer? ");
                        string transferDino = Console.ReadLine();

                        Console.Write("Which # enclosure should we move the dino to? ");
                        int newTransferEnclosure = int.Parse(Console.ReadLine());

                        Dinosaur dinoBeingTransferred = DinosaurDatabase.Transfer(transferDino, newTransferEnclosure);


                        if (dinoBeingTransferred != null)
                        {
                            Console.WriteLine($"{dinoBeingTransferred.Name} has been transferred.");
                        }
                        else
                        {
                            Console.WriteLine("This dino does not exist!");
                        }
                        break;

                    case "S":
                        DinosaurDatabase.Summary();
                        break;

                    case "V":

                        //Prompt user to select view in order name or enclosure
                        Console.WriteLine("Do you wish to view the dinos by (N)ame or (E)nclosure?");

                        //output is string from ReadLine
                        string orderInput = Console.ReadLine();
                        if (orderInput.ToUpper() == "N")
                        {
                            //If order by name
                            DinosaurDatabase.ViewDinos("Name");
                        }
                        else
                        if (orderInput.ToUpper() == "E")
                        {
                            //else
                            //if order by Enclosure
                            DinosaurDatabase.ViewDinos("Enclosure");
                        }


                        break;

                    case "Q":
                        keepGoing = false;
                        break;

                    default:
                        Console.WriteLine("Invalid input!");
                        break;



                }

            }
            Console.WriteLine("Thank you for visiting Jurassic Park!");

        }
    }


    static class DinosaurDatabase
    {
        static List<Dinosaur> dinos = new List<Dinosaur>() { };

        public static void ViewDinos(string orderBy)

        {
            if (dinos.Count == 0)
            {
                Console.WriteLine("Who let the dinos out??");
                return;
            }

            if (orderBy == "Name")
            {
                dinos = dinos.OrderBy(dino => dino.Name).ToList<Dinosaur>();
            }
            else
            if (orderBy == "Enclosure")
            {
                dinos = dinos.OrderBy(dino => dino.EnclosureNumber).ToList<Dinosaur>();

            }

            dinos.ForEach(dino => dino.Description());
            Console.WriteLine("--------------------------------");


        }

        public static Dinosaur Add(string diet, string name, int weight, int enclosure)
        {
            Dinosaur newDino = new Dinosaur(diet, name, weight, enclosure);
            dinos.Add(newDino);
            return newDino;
        }

        public static Dinosaur Remove(string name)
        {
            Dinosaur dinoToRemove = dinos.FirstOrDefault(dino => dino.Name.ToLower() == name.ToLower());
            if (dinoToRemove != null)
            {
                dinos.Remove(dinoToRemove);
                Console.WriteLine("Dino removed.");
            }
            return dinoToRemove;

        }
        public static Dinosaur Transfer(string name, int newEnclosure)
        {
            Dinosaur transferDino = dinos.FirstOrDefault(dino => dino.Name.ToLower() == name.ToLower());
            if (transferDino != null)
            {
                transferDino.EnclosureNumber = newEnclosure;
                Console.WriteLine("Dino updated!");
            }

            return transferDino;

        }


        public static void Summary()
        {
            int herbCount = dinos.Where(dino => dino.DietType == "herbivore").Count();
            int carnCount = dinos.Where(dino => dino.DietType == "carnivore").Count();

            Console.WriteLine($"There are {herbCount} herbivores and {carnCount} carnivores in our park.");

        }
    }
    public class Dinosaur
    {
        public string Name { get; set; }
        public string DietType { get; set; }
        public DateTime WhenAcquired { get; set; }
        public int Weight { get; set; }
        public int EnclosureNumber { get; set; }

        public Dinosaur(string diet, string name, int weight, int enclosure)
        {

            DietType = diet;
            Name = name;
            WhenAcquired = DateTime.Now;
            Weight = weight;
            EnclosureNumber = enclosure;


        }

        public void Description()
        {
            Console.WriteLine($"{Name} is a {DietType} that was acquired {WhenAcquired} and weighs {Weight} pounds and lives in pen number {EnclosureNumber}.");

        }

    }
}
