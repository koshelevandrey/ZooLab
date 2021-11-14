using System;
using Xunit;
using ZooLabLibrary;

namespace ZooLabTests
{
    public class VeterinarianTests
    {
        [Fact]
        public void ShouldBeAbleToCreateVeterinarian()
        {
            Veterinarian veterinarian = new Veterinarian("Ivan", "Petrov");
            Assert.NotNull(veterinarian);
            Assert.Equal("Ivan", veterinarian.FirstName);
            Assert.Equal("Petrov", veterinarian.LastName);
            Assert.Equal("", veterinarian.AnimalExperiences);
        }

        [Fact]
        public void ShouldBeAbleToAddAnimalExperience()
        {
            Veterinarian veterinarian = new Veterinarian("Ivan", "Petrov");
            veterinarian.AddAnimalExperience(new Lion(1, false));
            Assert.Equal("Lion;", veterinarian.AnimalExperiences);
            veterinarian.AddAnimalExperience(new Parrot(2, false));
            Assert.Equal("Lion;Parrot;", veterinarian.AnimalExperiences);
        }

        [Fact]
        public void ShouldBeAbleToHaveAnimalExperience()
        {
            Veterinarian veterinarian = new Veterinarian("Ivan", "Petrov");
            veterinarian.AddAnimalExperience(new Lion(1, false));
            Assert.True(veterinarian.HasAnimalExperience(new Lion(2, true)));
        }

        [Fact]
        public void ShouldBeAbleToHealAnimal()
        {
            Veterinarian veterinarian = new Veterinarian("Ivan", "Petrov");
            Lion lion = new Lion(1, false);
            veterinarian.AddAnimalExperience(lion);
            Assert.True(veterinarian.HealAnimal(lion));
        }

        [Fact]
        public void ShouldNotBeAbleToHealAnimal()
        {
            Veterinarian veterinarian = new Veterinarian("Ivan", "Petrov");
            Lion lion = new Lion(1, false);
            Assert.Throws<NotFriendlyAnimalException>(() => veterinarian.HealAnimal(lion));
        }
    }
}
