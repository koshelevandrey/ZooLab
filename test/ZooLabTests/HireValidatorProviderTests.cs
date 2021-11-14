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
            HireValidator validator = provider.GetHireValidator(zooKeeper);
            Assert.NotNull(validator);
            Assert.True(validator is ZooKeeperHireValidator);
        }

        [Fact]
        public void ShouldBeAbleToGetVeterinarianHireValidator()
        {
            HireValidatorProvider provider = new HireValidatorProvider();
            Veterinarian veterinarian = new Veterinarian("Ivan", "Petrov");
            HireValidator validator = provider.GetHireValidator(veterinarian);
            Assert.NotNull(validator);
            Assert.True(validator is VeterinarianHireValidator);
        }
    }
}
