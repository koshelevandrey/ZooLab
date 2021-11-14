using System;
using System.Collections.Generic;
using Xunit;
using ZooLabLibrary;

namespace ZooLabTests
{
    public class VeterinarianHireValidatorTests
    {
        [Fact]
        public void ShouldBeAbleToCreateValidator()
        {
            VeterinarianHireValidator validator = new VeterinarianHireValidator();
            Assert.NotNull(validator);
        }

        [Fact]
        public void ShouldBeAbleToValidateVeterinarian()
        {
            VeterinarianHireValidator validator = new VeterinarianHireValidator();
            Zoo zoo = new Zoo("Moscow");
            zoo.AddEnclosure("Large", 5000);
            Lion lion = new Lion(1, false);
            zoo.AddAnimal(lion);
            Veterinarian veterinarian = new Veterinarian("Ivan", "Petrov");
            veterinarian.AddAnimalExperience(lion);
            List<Exception> errors = validator.ValidateEmployee(veterinarian, zoo);
            Assert.Empty(errors);
        }

        [Fact]
        public void ShouldNotBeAbleToValidateVeterinarian()
        {
            VeterinarianHireValidator validator = new VeterinarianHireValidator();
            Zoo zoo = new Zoo("Moscow");
            zoo.AddEnclosure("Large", 5000);
            Lion lion = new Lion(1, false);
            zoo.AddAnimal(lion);
            Veterinarian veterinarian = new Veterinarian("Ivan", "Petrov");
            List<Exception> errors = validator.ValidateEmployee(veterinarian, zoo);
            Assert.Single(errors);
            Assert.Equal("Veterinarian Ivan Petrov must have experience at working with Lion",
                errors[0].Message);
        }

        [Fact]
        public void ShouldNotBeAbleToValidateZooKeeper()
        {
            VeterinarianHireValidator validator = new VeterinarianHireValidator();
            Zoo zoo = new Zoo("Moscow");
            zoo.AddEnclosure("Large", 5000);
            Lion lion = new Lion(1, false);
            zoo.AddAnimal(lion);
            ZooKeeper zooKeeper = new ZooKeeper("Ivan", "Petrov");
            zooKeeper.AddAnimalExperience(lion);
            List<Exception> errors = validator.ValidateEmployee(zooKeeper, zoo);
            Assert.Single(errors);
            Assert.Equal("Employee Ivan Petrov must be veterinarian to be validated with VeterinarianHireValidator",
                errors[0].Message);
        }
    }
}
