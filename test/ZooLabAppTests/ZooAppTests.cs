using System;
using System.IO;
using System.Text.RegularExpressions;
using Xunit;
using ZooLabLibrary;

namespace ZooLabAppTests
{
    public class ZooAppTests
    {
        [Fact]
        public void ShouldBeAbleToCreateZooApp()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            ZooApp app = new ZooApp();

            Assert.NotNull(app);

            // Initializing ZooApp with 2 zoos
            // Each has multiple enclosures to fit all types of animals
            Zoo zoo1 = new Zoo("London");
            Zoo zoo2 = new Zoo("New-York");
            app.AddZoo(zoo1);
            app.AddZoo(zoo2);

            Assert.Equal(zoo1, app.Zoos[0]);
            Assert.Equal(zoo2, app.Zoos[1]);

            zoo1.AddEnclosure("Large 1", 5000);
            zoo1.AddEnclosure("Large 2", 4000);
            zoo1.AddEnclosure("Medium 1", 2500);
            zoo1.AddEnclosure("Medium 2", 2000);
            zoo1.AddEnclosure("Small 1", 150);
            zoo1.AddEnclosure("Small 2", 105);
            zoo1.AddEnclosure("Smallest", 50);

            zoo2.AddEnclosure("Large 1", 5000);
            zoo2.AddEnclosure("Large 2", 4000);
            zoo2.AddEnclosure("Medium 1", 2500);
            zoo2.AddEnclosure("Medium 2", 2000);
            zoo2.AddEnclosure("Small 1", 150);
            zoo2.AddEnclosure("Small 2", 105);
            zoo2.AddEnclosure("Smallest", 50);

            //Add animals to first zoo

            // Lions
            int curId = 1;
            Lion lion1 = new Lion(curId++, false);
            zoo1.AddAnimal(lion1);
            Lion lion2 = new Lion(curId++, true);
            zoo1.AddAnimal(lion2);

            // Elephant and bison
            Elephant elephant = new Elephant(curId++, false);
            zoo1.AddAnimal(elephant);
            Bison bison = new Bison(curId++, false);
            zoo1.AddAnimal(bison);

            // Hire zookeeper
            ZooKeeper zooKeeper = new ZooKeeper("Ivan", "Petrov");
            zooKeeper.AddAnimalExperience(lion1);
            zooKeeper.AddAnimalExperience(elephant);
            zooKeeper.AddAnimalExperience(bison);
            zoo1.HireEmployee(zooKeeper);

            // Hire veterinarian
            Veterinarian veterinarian = new Veterinarian("John", "Smith");
            veterinarian.AddAnimalExperience(lion1);
            veterinarian.AddAnimalExperience(elephant);
            veterinarian.AddAnimalExperience(bison);
            zoo1.HireEmployee(veterinarian);

            // Penguins
            Penguin penguin1 = new Penguin(curId++, false);
            zoo1.AddAnimal(penguin1);
            Penguin penguin2 = new Penguin(curId++, false);
            zoo1.AddAnimal(penguin2);
            Penguin penguin3 = new Penguin(curId++, true);
            zoo1.AddAnimal(penguin3);
            Penguin penguin4 = new Penguin(curId++, false);
            zoo1.AddAnimal(penguin4);

            // Parrots and turtles
            Parrot parrot1 = new Parrot(curId++, true);
            zoo1.AddAnimal(parrot1);
            Parrot parrot2 = new Parrot(curId++, false);
            zoo1.AddAnimal(parrot2);
            Turtle turtle1 = new Turtle(curId++, true);
            zoo1.AddAnimal(turtle1);
            Turtle turtle2 = new Turtle(curId++, true);
            zoo1.AddAnimal(turtle2);

            // Snakes
            Snake snake1 = new Snake(curId++, false);
            zoo1.AddAnimal(snake1);
            Snake snake2 = new Snake(curId++, false);
            zoo1.AddAnimal(snake2);
            Snake snake3 = new Snake(curId++, true);
            zoo1.AddAnimal(snake3);

            // Hire more employees
            ZooKeeper zooKeeper2 = new ZooKeeper("Dmitri", "Kuznetcov");
            zooKeeper2.AddAnimalExperience(lion1);
            zooKeeper2.AddAnimalExperience(elephant);
            zooKeeper2.AddAnimalExperience(bison);
            zooKeeper2.AddAnimalExperience(penguin1);
            zooKeeper2.AddAnimalExperience(parrot1);
            zooKeeper2.AddAnimalExperience(turtle1);
            zooKeeper2.AddAnimalExperience(snake1);
            zoo1.HireEmployee(zooKeeper2);

            Veterinarian veterinarian2 = new Veterinarian("Thomas", "Wayne");
            veterinarian2.AddAnimalExperience(lion1);
            veterinarian2.AddAnimalExperience(elephant);
            veterinarian2.AddAnimalExperience(bison);
            veterinarian2.AddAnimalExperience(penguin1);
            veterinarian2.AddAnimalExperience(parrot1);
            veterinarian2.AddAnimalExperience(turtle1);
            veterinarian2.AddAnimalExperience(snake1);
            zoo1.HireEmployee(veterinarian2);

            // Feed and heal animals
            zoo1.FeedAnimals(DateTime.Now);
            zoo1.HealAnimals();

            var expectedOutput = "Zoo at London was added to ZooApp" +
                                 "Zoo at New-York was added to ZooApp" +
                                 "Enclosure \"Large 1\" was added to zoo at London" +
                                 "Enclosure \"Large 2\" was added to zoo at London" +
                                 "Enclosure \"Medium 1\" was added to zoo at London" +
                                 "Enclosure \"Medium 2\" was added to zoo at London" +
                                 "Enclosure \"Small 1\" was added to zoo at London" +
                                 "Enclosure \"Small 2\" was added to zoo at London" +
                                 "Enclosure \"Smallest\" was added to zoo at London" +
                                 "Enclosure \"Large 1\" was added to zoo at New-York" +
                                 "Enclosure \"Large 2\" was added to zoo at New-York" +
                                 "Enclosure \"Medium 1\" was added to zoo at New-York" +
                                 "Enclosure \"Medium 2\" was added to zoo at New-York" +
                                 "Enclosure \"Small 1\" was added to zoo at New-York" +
                                 "Enclosure \"Small 2\" was added to zoo at New-York" +
                                 "Enclosure \"Smallest\" was added to zoo at New-York" +
                                 "Animal Lion#1 was added to enclosure Large 1" +
                                 "Animal Lion#2 was added to enclosure Large 1" +
                                 "Animal Elephant#3 was added to enclosure Large 2" +
                                 "Animal Bison#4 was added to enclosure Large 2" +
                                 "Employee Ivan Petrov was hired to zoo at London" +
                                 "Employee John Smith was hired to zoo at London" +
                                 "Animal Penguin#5 was added to enclosure Medium 1" +
                                 "Animal Penguin#6 was added to enclosure Medium 1" +
                                 "Animal Penguin#7 was added to enclosure Medium 1" +
                                 "Animal Penguin#8 was added to enclosure Medium 1" +
                                 "Animal Parrot#9 was added to enclosure Medium 2" +
                                 "Animal Parrot#10 was added to enclosure Medium 2" +
                                 "Animal Turtle#11 was added to enclosure Medium 2" +
                                 "Animal Turtle#12 was added to enclosure Medium 2" +
                                 "Animal Snake#13 was added to enclosure Small 1" +
                                 "Animal Snake#14 was added to enclosure Small 1" +
                                 "Animal Snake#15 was added to enclosure Small 1" +
                                 "Employee Dmitri Kuznetcov was hired to zoo at London" +
                                 "Employee Thomas Wayne was hired to zoo at London" +
                                 "Animal Lion#1 was fed by zookeeper Ivan Petrov" +
                                 "Animal Lion#2 was fed by zookeeper Ivan Petrov" +
                                 "Animal Elephant#3 was fed by zookeeper Ivan Petrov" +
                                 "Animal Bison#4 was fed by zookeeper Ivan Petrov" +
                                 "Animal Penguin#5 was fed by zookeeper Dmitri Kuznetcov" +
                                 "Animal Penguin#6 was fed by zookeeper Dmitri Kuznetcov" +
                                 "Animal Penguin#7 was fed by zookeeper Dmitri Kuznetcov" +
                                 "Animal Penguin#8 was fed by zookeeper Dmitri Kuznetcov" +
                                 "Animal Parrot#9 was fed by zookeeper Dmitri Kuznetcov" +
                                 "Animal Parrot#10 was fed by zookeeper Dmitri Kuznetcov" +
                                 "Animal Turtle#11 was fed by zookeeper Dmitri Kuznetcov" +
                                 "Animal Turtle#12 was fed by zookeeper Dmitri Kuznetcov" +
                                 "Animal Snake#13 was fed by zookeeper Dmitri Kuznetcov" +
                                 "Animal Snake#14 was fed by zookeeper Dmitri Kuznetcov" +
                                 "Animal Snake#15 was fed by zookeeper Dmitri Kuznetcov" +
                                 "Animal Lion#2 was healed by veterinarian John Smith" +
                                 "Animal Penguin#7 was healed by veterinarian Thomas Wayne" +
                                 "Animal Parrot#9 was healed by veterinarian Thomas Wayne" +
                                 "Animal Turtle#11 was healed by veterinarian Thomas Wayne" +
                                 "Animal Turtle#12 was healed by veterinarian Thomas Wayne" +
                                 "Animal Snake#15 was healed by veterinarian Thomas Wayne";

            Assert.Equal(expectedOutput, Regex.Replace(output.ToString(), @"[\r\t\n]+", string.Empty));
        }
    }
}
