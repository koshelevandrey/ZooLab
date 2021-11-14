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
            List<Exception> errors = validator.ValidateEmployee(zooKeeper, zoo);
            Assert.Empty(errors);
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
            List<Exception> errors = validator.ValidateEmployee(zooKeeper, zoo);
            Assert.Single(errors);
            Assert.Equal("Zookeeper Ivan Petrov must have experience at working with Lion",
                errors[0].Message);
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
            List<Exception> errors = validator.ValidateEmployee(veterinarian, zoo);
            Assert.Single(errors);
            Assert.Equal("Employee Ivan Petrov must be zookeeper to be validated with ZooKeeperHireValidator",
                errors[0].Message);
        }
    }
}
