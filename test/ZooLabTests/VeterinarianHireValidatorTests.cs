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
            validator.ValidateEmployee(veterinarian, zoo);
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
            Assert.Throws<NoNeededExperienceException>(() => validator.ValidateEmployee(veterinarian, zoo));
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
            Assert.Throws<Exception>(() => validator.ValidateEmployee(zooKeeper, zoo));
        }
    }
}
