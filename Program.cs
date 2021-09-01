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
            DinosaurDatabase.Add("carnivore", "Godzilla", 328000000, 1);
            DinosaurDatabase.Add("carnivore", "T-Rex", 13000, 1);
            DinosaurDatabase.Add("carnivore", "Steve", 8000, 2);
            DinosaurDatabase.Add("herbivore", "Sarah", 12500, 3);
            DinosaurDatabase.Add("herbivore", "Buttons", 2, 100);

            DinosaurDatabase.ViewDinos("Name");
            Console.WriteLine("---------------------------------");
            DinosaurDatabase.ViewDinos("Enclosure");

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
}