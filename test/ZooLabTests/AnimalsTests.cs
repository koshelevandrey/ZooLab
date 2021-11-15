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
            Assert.True(lion.FavoriteFood is Meat);
        }

        [Fact]
        public void ShouldBeAbleToCreateElephant()
        {
            Elephant elephant = new Elephant(1, false);
            Assert.NotNull(elephant);
            Assert.Equal(1000, elephant.RequiredSpaceSqtFt);
            Assert.True(elephant.FavoriteFood is Meat);
        }

        [Fact]
        public void ShouldBeAbleToCreateBison()
        {
            Bison bison = new Bison(1, false);
            Assert.NotNull(bison);
            Assert.Equal(1000, bison.RequiredSpaceSqtFt);
            Assert.True(bison.FavoriteFood is Meat);

        }

        [Fact]
        public void ShouldBeAbleToCreatePenguin()
        {
            Penguin penguin = new Penguin(1, false);
            Assert.NotNull(penguin);
            Assert.Equal(10, penguin.RequiredSpaceSqtFt);
            Assert.True(penguin.FavoriteFood is Meat);
        }

        [Fact]
        public void ShouldBeAbleToCreateParrot()
        {
            Parrot parrot = new Parrot(1, false);
            Assert.NotNull(parrot);
            Assert.Equal(5, parrot.RequiredSpaceSqtFt);
            Assert.True(parrot.FavoriteFood is Vegetable);
        }

        [Fact]
        public void ShouldBeAbleToCreateTurtle()
        {
            Turtle turtle = new Turtle(1, false);
            Assert.NotNull(turtle);
            Assert.Equal(5, turtle.RequiredSpaceSqtFt);
            Assert.True(turtle.FavoriteFood is Grass);
        }

        [Fact]
        public void ShouldBeAbleToCreateSnake()
        {
            Snake snake = new Snake(1, false);
            Assert.NotNull(snake);
            Assert.Equal(2, snake.RequiredSpaceSqtFt);
            Assert.True(snake.FavoriteFood is Meat);
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
