using System;
using System.Collections.Generic;

namespace ZooLabLibrary
{
    public class Parrot : Bird
    {
        public Parrot(int id, bool isSick) : base(id, isSick)
        {
        }

        public override int RequiredSpaceSqtFt => 5;
        public override Food FavoriteFood => Food.Vegetable;

        public override bool IsFriendlyWithAnimal(Animal animal)
        {
            return animal is Parrot || animal is Bison || animal is Elephant || animal is Turtle;
        }
    }
}
