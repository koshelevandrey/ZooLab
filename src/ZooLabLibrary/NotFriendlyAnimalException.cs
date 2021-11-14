using System;

namespace ZooLabLibrary
{
    [Serializable]
    public class NotFriendlyAnimalException : Exception
    {
        public NotFriendlyAnimalException() : base() { }
    }
}
