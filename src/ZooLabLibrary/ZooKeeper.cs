using System;

namespace ZooLabLibrary
{
    public class ZooKeeper : IEmployee
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string AnimalExperiences { get; private set; }

        public ZooKeeper(string firstName, string lastName)
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

        public bool FeedAnimal(Animal animal)
        {
            if (!HasAnimalExperience(animal))
            {
                throw new NotFriendlyAnimalException();
            }
            animal.Feed(animal.FavoriteFood);
            animal.FeedTimes.Add(new FeedTime(DateTime.Now, this));
            Console.WriteLine($"Animal {animal.GetType().Name}#{animal.ID} was fed by zookeeper {this.FirstName} {this.LastName}");
            return true;
        }
    }
}
