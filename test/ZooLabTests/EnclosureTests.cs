using System;
using System.Collections.Generic;
using Xunit;
using ZooLabLibrary;

namespace ZooLabTests
{
    public class EnclosureTests
    {
        [Fact]
        public void ShouldBeAbleToCreateEnclosure()
        {
            Zoo zoo = new Zoo("Moscow");
            Enclosure enclosure = new Enclosure("123", zoo, 250);
            Assert.NotNull(enclosure);
            Assert.Equal("123", enclosure.Name);
            Assert.Equal(250, enclosure.SquareFeet);
            Assert.Equal(zoo, enclosure.ParentZoo);
        }

        [Fact]
        public void ShouldBeAbleToAddAnimal()
        {
            Zoo zoo = new Zoo("Moscow");
            Enclosure enclosure = new Enclosure("123", zoo, 250);
            Parrot parrot = new Parrot(1, false);
            enclosure.AddAnimal(parrot);
            Assert.Equal(parrot, enclosure.Animals[0]);
        }

        [Fact]
        public void ShouldNotBeAbleToAddAnimal()
        {
            Zoo zoo = new Zoo("Moscow");
            Enclosure enclosure = new Enclosure("123", zoo, 250);
            Lion lion = new Lion(1, false);
            Assert.Throws<NoAvailableSpaceException>(() => enclosure.AddAnimal(lion));
        }
    }
}
