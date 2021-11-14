using System;
using System.Collections.Generic;

namespace ZooLabLibrary
{
    public abstract class Animal
    {
        public abstract int RequiredSpaceSqtFt { get; }
        public abstract Food FavoriteFood { get; }
        public List<FeedTime> FeedTimes { get; }
        public List<int> FeedSchedule { get; }
        public bool IsSick { get; set; }
        public int ID { get; }

        public Animal(int id, bool isSick)
        {
            FeedTimes = new List<FeedTime>();
            FeedSchedule = new List<int>();
            IsSick = isSick;
            ID = id;
        }

        public abstract bool IsFriendlyWithAnimal(Animal animal);

        public void Feed(Food food)
        {
            // Nothing to do here
        }

        public void AddFeedSchedule(List<int> hours)
        {
            FeedSchedule.AddRange(hours);
        }

        public void Heal(Medicine medicine)
        {
            IsSick = false;
        }
    }
}
