using System;
using System.Collections.Generic;

namespace ZooLabLibrary
{
    public class Bison : Mammal
    {
        public Bison(int id, bool isSick) : base(id, isSick)
        {
        }

        public override int RequiredSpaceSqtFt => 1000;
        public override Food FavoriteFood => Food.Meat;

        public override bool IsFriendlyWithAnimal(Animal animal)
        {
            return animal is Elephant;
        }
    }
}
