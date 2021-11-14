using System;
using System.Collections.Generic;

namespace ZooLabLibrary
{
    public abstract class Mammal : Animal
    {
        public Mammal(int id, bool isSick) : base(id, isSick)
        {
        }
    }
}
