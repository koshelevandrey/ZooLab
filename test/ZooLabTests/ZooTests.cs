using System;
using Xunit;
using ZooLabLibrary;

namespace ZooLabTests
{
    public class ZooTests
    {
        [Fact]
        public void ShouldBeAbleToCreateZoo()
        {
            Zoo zoo = new Zoo("London");
            Assert.NotNull(zoo);
            Assert.Equal("London", zoo.Location);
        }

        [Fact]
        public void ShouldBeAbleToAddEnclosure()
        {
            Zoo zoo = new Zoo("London");
            zoo.AddEnclosure("Large", 5000);
        }

        [Fact]
        public void ShouldBeAbleToAddAnimals()
        {
            Zoo zoo = new Zoo("London");
            zoo.AddEnclosure("1", 1000);
            zoo.AddEnclosure("2", 1000);
            Lion lion1 = new Lion(1, false);
            zoo.AddAnimal(lion1);
            Lion lion2 = new Lion(2, false);
            zoo.AddAnimal(lion2);
        }

        [Fact]
        public void ShouldNotBeAbleToAddAnimals()
        {
            Zoo zoo = new Zoo("London");
            zoo.AddEnclosure("1", 1000);
            zoo.AddEnclosure("2", 1000);
            Lion lion1 = new Lion(1, false);
            zoo.AddAnimal(lion1);
            Lion lion2 = new Lion(2, false);
            zoo.AddAnimal(lion2);
            Lion lion3 = new Lion(3, false);
            Assert.Throws<NoAvailableEnclosureException>(() => zoo.AddAnimal(lion3));
        }

        [Fact]
        public void ShouldBeAbleToHireEmployee()
        {
            Zoo zoo = new Zoo("London");
            zoo.AddEnclosure("Large", 5000);
            Lion lion1 = new Lion(1, false);
            zoo.AddAnimal(lion1);
            ZooKeeper zooKeeper = new ZooKeeper("Ivan", "Petrov");
            zooKeeper.AddAnimalExperience(lion1);
            zoo.HireEmployee(zooKeeper);
        }
    }
}
