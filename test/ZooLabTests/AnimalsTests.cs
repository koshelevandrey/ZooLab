using System;
using System.Collections.Generic;
using Xunit;
using ZooLabLibrary;

namespace ZooLabTests
{
    public class AnimalsTests
    {
        [Fact]
        public void ShouldBeAbleToCreateLion()
        {
            Lion lion = new Lion(1, false);
            Assert.NotNull(lion);
            Assert.Equal(1000, lion.RequiredSpaceSqtFt);
            Assert.Equal(Food.Meat, lion.FavoriteFood);
        }

        [Fact]
        public void ShouldBeAbleToCreateElephant()
        {
            Elephant elephant = new Elephant(1, false);
            Assert.NotNull(elephant);
            Assert.Equal(1000, elephant.RequiredSpaceSqtFt);
            Assert.Equal(Food.Meat, elephant.FavoriteFood);
        }

        [Fact]
        public void ShouldBeAbleToCreateBison()
        {
            Bison bison = new Bison(1, false);
            Assert.NotNull(bison);
            Assert.Equal(1000, bison.RequiredSpaceSqtFt);
            Assert.Equal(Food.Meat, bison.FavoriteFood);
        }

        [Fact]
        public void ShouldBeAbleToCreatePenguin()
        {
            Penguin penguin = new Penguin(1, false);
            Assert.NotNull(penguin);
            Assert.Equal(10, penguin.RequiredSpaceSqtFt);
            Assert.Equal(Food.Meat, penguin.FavoriteFood);
        }

        [Fact]
        public void ShouldBeAbleToCreateParrot()
        {
            Parrot parrot = new Parrot(1, false);
            Assert.NotNull(parrot);
            Assert.Equal(5, parrot.RequiredSpaceSqtFt);
            Assert.Equal(Food.Vegetable, parrot.FavoriteFood);
        }

        [Fact]
        public void ShouldBeAbleToCreateTurtle()
        {
            Turtle turtle = new Turtle(1, false);
            Assert.NotNull(turtle);
            Assert.Equal(5, turtle.RequiredSpaceSqtFt);
            Assert.Equal(Food.Grass, turtle.FavoriteFood);
        }

        [Fact]
        public void ShouldBeAbleToCreateSnake()
        {
            Snake snake = new Snake(1, false);
            Assert.NotNull(snake);
            Assert.Equal(2, snake.RequiredSpaceSqtFt);
            Assert.Equal(Food.Meat, snake.FavoriteFood);
        }

        [Fact]
        public void ShouldReturnFalseFromAnimalIsSick()
        {
            Lion lion = new Lion(1, false);
            Assert.False(lion.IsSick);
        }

        [Fact]
        public void ShouldReturnTrueFromAnimalIsSick()
        {
            Lion lion = new Lion(1, true);
            Assert.True(lion.IsSick);
        }

        [Fact]
        public void ShouldBeAbleToAddFeedSchedule()
        {
            Elephant elephant = new Elephant(1, false);
            List<int> schedule = new List<int>();
            schedule.Add(10);
            schedule.Add(15);
            elephant.AddFeedSchedule(schedule);
            Assert.Equal(10, elephant.FeedSchedule[0]);
            Assert.Equal(15, elephant.FeedSchedule[1]);
        }
    }
}
