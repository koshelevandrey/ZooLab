using System;
using System.Collections.Generic;

namespace ZooLabLibrary
{
    public class Enclosure
    {
        public string Name { get; private set; }
        public List<Animal> Animals { get; private set; }
        public Zoo ParentZoo { get; private set; }
        public int SquareFeet { get; private set; }

        public Enclosure(string name, Zoo parentZoo, int squareFeet)
        {
            Name = name;
            ParentZoo = parentZoo;
            SquareFeet = squareFeet;
            Animals = new List<Animal>();
        }

        public void AddAnimal(Animal animal)
        {
            int enclosureOccupiedSpace = 0;
            foreach (Animal enclosureAnimal in this.Animals)
            {
                enclosureOccupiedSpace += enclosureAnimal.RequiredSpaceSqtFt;
            }

            // Not enough space for animal in this enclosure
            if (enclosureOccupiedSpace + animal.RequiredSpaceSqtFt > this.SquareFeet)
            {
                throw new NoAvailableSpaceException($"No space for {animal.GetType().Name}#{animal.ID}at enclosure {this.Name}");
            }

            Console.WriteLine($"Animal {animal.GetType().Name}#{animal.ID} was added to enclosure {this.Name}");
            Animals.Add(animal);
        }
    }
}
