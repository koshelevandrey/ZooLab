using System;
using System.Collections.Generic;

namespace ZooLabLibrary
{
    public class Turtle : Reptile
    {
        public Turtle(int id, bool isSick) : base(id, isSick)
        {
        }

        public override int RequiredSpaceSqtFt => 5;
        public override Food FavoriteFood => new Grass();

        public override bool IsFriendlyWithAnimal(Animal animal)
        {
            return animal is Parrot || animal is Bison || animal is Elephant || animal is Turtle;
        }
    }
}
