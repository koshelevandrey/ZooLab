using System;

namespace ZooLabLibrary
{
    public class Veterinarian : IEmployee
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string AnimalExperiences { get; private set; }

        public Veterinarian(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            AnimalExperiences = "";
        }

        public void AddAnimalExperience(Animal animal)
        {
            if (!HasAnimalExperience(animal))
            {
                AnimalExperiences += animal.GetType().Name + ";";
            }
        }

        public bool HasAnimalExperience(Animal animal)
        {
            return AnimalExperiences.Contains(animal.GetType().Name);
        }

        public bool HealAnimal(Animal animal)
        {
            if (!HasAnimalExperience(animal))
            {
                throw new NotFriendlyAnimalException();
            }
            if (!animal.IsSick)
            {
                //Console.WriteLine($"Animal {animal.GetType().Name}#{animal.ID} is not sick");
                return true;
            }
            animal.Heal(Medicine.Antibiotics);
            Console.WriteLine($"Animal {animal.GetType().Name}#{animal.ID} was healed by veterinarian {this.FirstName} {this.LastName}");
            return true;
        }
    }
}
