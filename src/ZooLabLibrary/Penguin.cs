using System;
using System.Collections.Generic;

namespace ZooLabLibrary
{
    public class Penguin : Bird
    {
        public Penguin(int id, bool isSick) : base(id, isSick)
        {
        }

        public override int RequiredSpaceSqtFt => 10;
        public override Food FavoriteFood => new Meat();

        public override bool IsFriendlyWithAnimal(Animal animal)
        {
            return animal is Penguin;
        }
    }
}
