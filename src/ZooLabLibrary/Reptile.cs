using System;
using System.Collections.Generic;

namespace ZooLabLibrary
{
    public abstract class Reptile : Animal
    {
        public Reptile(int id, bool isSick) : base(id, isSick)
        {
        }
    }
}
