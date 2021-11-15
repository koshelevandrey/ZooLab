using System;
using System.Collections.Generic;

namespace ZooLabLibrary
{
    public class Lion : Mammal
    {
        public Lion(int id, bool isSick) : base(id, isSick)
        {
        }

        public override int RequiredSpaceSqtFt => 1000;
        public override Food FavoriteFood => new Meat();

        public override bool IsFriendlyWithAnimal(Animal animal)
        {
            return animal is Lion;
        }
    }
}
