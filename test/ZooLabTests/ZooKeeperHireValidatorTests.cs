using System;
using System.Collections.Generic;
using Xunit;
using ZooLabLibrary;

namespace ZooLabTests
{
    public class ZooKeeperHireValidatorTests
    {
        [Fact]
        public void ShouldBeAbleToCreateValidator()
        {
            ZooKeeperHireValidator validator = new ZooKeeperHireValidator();
            Assert.NotNull(validator);
        }

        [Fact]
        public void ShouldBeAbleToValidateZooKeeper()
        {
            ZooKeeperHireValidator validator = new ZooKeeperHireValidator();
            Zoo zoo = new Zoo("Moscow");
            zoo.AddEnclosure("Large", 5000);
            Lion lion = new Lion(1, false);
            zoo.AddAnimal(lion);
            ZooKeeper zooKeeper = new ZooKeeper("Ivan", "Petrov");
            zooKeeper.AddAnimalExperience(lion);
            validator.ValidateEmployee(zooKeeper, zoo);
        }

        [Fact]
        public void ShouldNotBeAbleToValidateZooKeeper()
        {
            ZooKeeperHireValidator validator = new ZooKeeperHireValidator();
            Zoo zoo = new Zoo("Moscow");
            zoo.AddEnclosure("Large", 5000);
            Lion lion = new Lion(1, false);
            zoo.AddAnimal(lion);
            ZooKeeper zooKeeper = new ZooKeeper("Ivan", "Petrov");
            Assert.Throws<NoNeededExperienceException>(() => validator.ValidateEmployee(zooKeeper, zoo));
        }

        [Fact]
        public void ShouldNotBeAbleToValidateVeterinarian()
        {
            ZooKeeperHireValidator validator = new ZooKeeperHireValidator();
            Zoo zoo = new Zoo("Moscow");
            zoo.AddEnclosure("Large", 5000);
            Lion lion = new Lion(1, false);
            zoo.AddAnimal(lion);
            Veterinarian veterinarian = new Veterinarian("Ivan", "Petrov");
            Assert.Throws<Exception>(() => validator.ValidateEmployee(veterinarian, zoo));
        }
    }
}
