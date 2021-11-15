using System;
using Xunit;
using ZooLabLibrary;

namespace ZooLabTests
{
    public class HireValidatorProviderTests
    {
        [Fact]
        public void ShouldBeAbleToCreateProvider()
        {
            HireValidatorProvider provider = new HireValidatorProvider();
            Assert.NotNull(provider);
        }

        [Fact]
        public void ShouldBeAbleToGetZooKeeperHireValidator()
        {
            HireValidatorProvider provider = new HireValidatorProvider();
            ZooKeeper zooKeeper = new ZooKeeper("Ivan", "Petrov");
            IHireValidator validator = provider.GetHireValidator(zooKeeper);
            Assert.NotNull(validator);
            Assert.True(validator is ZooKeeperHireValidator);
        }

        [Fact]
        public void ShouldBeAbleToGetVeterinarianHireValidator()
        {
            HireValidatorProvider provider = new HireValidatorProvider();
            Veterinarian veterinarian = new Veterinarian("Ivan", "Petrov");
            IHireValidator validator = provider.GetHireValidator(veterinarian);
            Assert.NotNull(validator);
            Assert.True(validator is VeterinarianHireValidator);
        }

        private class Janitor : IEmployee
        {
            public string FirstName { get; private set; }
            public string LastName { get; private set; }

            public Janitor(string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
            }
        }

        [Fact]
        public void ShouldNotBeAbleToGetJanitorHireValidator()
        {
            HireValidatorProvider provider = new HireValidatorProvider();
            Janitor janitor = new Janitor("Ivan", "Petrov");
            Assert.Throws<Exception>(() => provider.GetHireValidator(janitor));
        }
    }
}
