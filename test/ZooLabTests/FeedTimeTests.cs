using System;
using Xunit;
using ZooLabLibrary;

namespace ZooLabTests
{
    public class FeedTimeTests
    {
        [Fact]
        public void ShouldBeAbleToCreateFeedTime()
        {
            DateTime now = DateTime.Now;
            ZooKeeper zooKeeper = new ZooKeeper("Ivan", "Petrov");
            FeedTime feedTime = new FeedTime(now, zooKeeper);
            Assert.NotNull(feedTime);
            Assert.Equal(now, feedTime.Time);
            Assert.Equal(zooKeeper, feedTime.FeedByZooKeeper);
        }
    }
}
