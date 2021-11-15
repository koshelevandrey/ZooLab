using System;
using System.Collections.Generic;

namespace ZooLabLibrary
{
    public class Snake : Reptile
    {
        public Snake(int id, bool isSick) : base(id, isSick)
        {
        }

        public override int RequiredSpaceSqtFt => 2;
        public override Food FavoriteFood => new Meat();

        public override bool IsFriendlyWithAnimal(Animal animal)
        {
            return animal is Snake;
        }
    }
}
