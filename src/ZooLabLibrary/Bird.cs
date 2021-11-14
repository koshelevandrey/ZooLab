using System;
using System.Collections.Generic;

namespace ZooLabLibrary
{
    public abstract class Bird : Animal
    {
        public Bird(int id, bool isSick) : base(id, isSick)
        {
        }
    }
}
