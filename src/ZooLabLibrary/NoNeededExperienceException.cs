using System;

namespace ZooLabLibrary
{
    [Serializable]
    public class NoNeededExperienceException : Exception
    {
        public NoNeededExperienceException(string message) : base(message) { }
    }
}
