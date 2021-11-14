using System;

namespace ZooLabLibrary
{
    [Serializable]
    public class NoAvailableEnclosureException : Exception
    {
        public NoAvailableEnclosureException() : base() { }
    }
}
