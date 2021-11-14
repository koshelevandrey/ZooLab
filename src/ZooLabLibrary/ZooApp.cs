using System;
using System.Collections.Generic;

namespace ZooLabLibrary
{
    public class ZooApp
    {
        private List<Zoo> _zoos;

        public List<Zoo> Zoos
        {
            get
            {
                return _zoos;
            }
        }


        public ZooApp()
        {
            _zoos = new List<Zoo>();
        }

        public void AddZoo(Zoo zoo)
        {
            Console.WriteLine($"Zoo at {zoo.Location} was added to ZooApp");
            _zoos.Add(zoo);
        }
    }
}
