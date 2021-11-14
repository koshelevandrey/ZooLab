using System;

namespace ZooLabLibrary
{
    public class FeedTime
    {
        public DateTime Time;
        public ZooKeeper FeedByZooKeeper;

        public FeedTime(DateTime feedTime, ZooKeeper feedByZooKeeper)
        {
            Time = feedTime;
            FeedByZooKeeper = feedByZooKeeper;
        }
    }
}
