using System;
using System.Collections.Generic;

namespace ZooLabLibrary
{
    public class Elephant : Mammal
    {
        public Elephant(int id, bool isSick) : base(id, isSick)
        {
        }

        public override int RequiredSpaceSqtFt => 1000;
        public override Food FavoriteFood => new Meat();

        public override bool IsFriendlyWithAnimal(Animal animal)
        {
            return animal is Bison || animal is Parrot || animal is Turtle;
        }
    }
}
