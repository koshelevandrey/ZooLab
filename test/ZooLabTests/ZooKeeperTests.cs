using System;
using Xunit;
using ZooLabLibrary;

namespace ZooLabTests
{
    public class ZooKeeperTests
    {
        [Fact]
        public void ShouldBeAbleToCreateZooKeeper()
        {
            ZooKeeper zooKeeper = new ZooKeeper("Ivan", "Petrov");
            Assert.NotNull(zooKeeper);
            Assert.Equal("Ivan", zooKeeper.FirstName);
            Assert.Equal("Petrov", zooKeeper.LastName);
            Assert.Equal("", zooKeeper.AnimalExperiences);
        }

        [Fact]
        public void ShouldBeAbleToAddAnimalExperience()
        {
            ZooKeeper zooKeeper = new ZooKeeper("Ivan", "Petrov");
            zooKeeper.AddAnimalExperience(new Lion(1, false));
            Assert.Equal("Lion;", zooKeeper.AnimalExperiences);
            zooKeeper.AddAnimalExperience(new Parrot(2, false));
            Assert.Equal("Lion;Parrot;", zooKeeper.AnimalExperiences);
        }

        [Fact]
        public void ShouldBeAbleToHaveAnimalExperience()
        {
            ZooKeeper zooKeeper = new ZooKeeper("Ivan", "Petrov");
            zooKeeper.AddAnimalExperience(new Lion(1, false));
            Assert.True(zooKeeper.HasAnimalExperience(new Lion(2, true)));
        }

        [Fact]
        public void ShouldBeAbleToFeedAnimal()
        {
            ZooKeeper zooKeeper = new ZooKeeper("Ivan", "Petrov");
            Lion lion = new Lion(1, false);
            zooKeeper.AddAnimalExperience(lion);
            Assert.True(zooKeeper.FeedAnimal(lion));
        }

        [Fact]
        public void ShouldNotBeAbleToFeedAnimal()
        {
            ZooKeeper zooKeeper = new ZooKeeper("Ivan", "Petrov");
            Lion lion = new Lion(1, false);
            Assert.Throws<NotFriendlyAnimalException>(() => zooKeeper.FeedAnimal(lion));
        }
    }
}
