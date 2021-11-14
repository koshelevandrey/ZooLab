using System;

namespace ZooLabLibrary
{
    [Serializable]
    public class NoAvailableSpaceException : Exception
    {
        public NoAvailableSpaceException(string message) : base(message) { }
    }
}
