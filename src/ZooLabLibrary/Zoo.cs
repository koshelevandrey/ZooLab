using System;
using System.Collections.Generic;

namespace ZooLabLibrary
{
    public class Zoo
    {
        private List<Enclosure> Enclosures { get; set; }
        private List<IEmployee> Employees { get; set; }
        public string Location { get; private set; }

        public Zoo(string location)
        {
            Location = location;
            Enclosures = new List<Enclosure>();
            Employees = new List<IEmployee>();
        }

        public Enclosure AddEnclosure(string name, int squareFeet)
        {
            Enclosure enclosure = new Enclosure(name, this, squareFeet);
            Enclosures.Add(enclosure);
            Console.WriteLine($"Enclosure \"{name}\" was added to zoo at {this.Location}");
            return enclosure;
        }

        public bool AddAnimal(Animal animal)
        {
            Enclosure enclosureForAnimal = this.FindAvailableEnclosure(animal);
            enclosureForAnimal.AddAnimal(animal);
            return true;
        }

        public Enclosure FindAvailableEnclosure(Animal animal)
        {
            foreach (Enclosure enclosure in Enclosures)
            {
                int enclosureOccupiedSpace = 0;
                foreach (Animal enclosureAnimal in enclosure.Animals)
                {
                    enclosureOccupiedSpace += enclosureAnimal.RequiredSpaceSqtFt;
                }

                // Not enough space for animal in this enclosure
                if (enclosureOccupiedSpace + animal.RequiredSpaceSqtFt > enclosure.SquareFeet)
                {
                    continue;
                }

                bool isFriendlyWithAll = true;
                foreach (Animal enclosureAnimal in enclosure.Animals)
                {
                    if (!enclosureAnimal.IsFriendlyWithAnimal(animal))
                    {
                        isFriendlyWithAll = false;
                        break;
                    }
                }

                if (isFriendlyWithAll && (enclosureOccupiedSpace + animal.RequiredSpaceSqtFt <= enclosure.SquareFeet))
                {
                    return enclosure;
                }
            }

            // Couldn't find available enclosure
            throw new NoAvailableEnclosureException();
        }

        public void HireEmployee(IEmployee employee)
        {
            HireValidatorProvider provider = new HireValidatorProvider();
            IHireValidator validator = provider.GetHireValidator(employee);
            validator.ValidateEmployee(employee, this);
            // If no exceptions were thrown, validation is alright
            Console.WriteLine($"Employee {employee.FirstName} {employee.LastName} was hired to zoo at {this.Location}");
            Employees.Add(employee);
        }

        // Get all types of animals in this zoo
        public List<string> GetAnimalTypes()
        {
            List<string> zooAnimalsTypes = new List<string>();
            foreach (Enclosure enclosure in this.Enclosures)
            {
                foreach (Animal animal in enclosure.Animals)
                {
                    string animalType = animal.GetType().Name;
                    if (!zooAnimalsTypes.Contains(animalType))
                    {
                        zooAnimalsTypes.Add(animalType);
                    }
                }
            }
            return zooAnimalsTypes;
        }

        public void FeedAnimals(DateTime time)
        {
            foreach (Enclosure enclosure in Enclosures)
            {
                foreach (Animal animal in enclosure.Animals)
                {
                    foreach (IEmployee employee in Employees)
                    {
                        if (employee is ZooKeeper)
                        {
                            ZooKeeper zooKeeper = (ZooKeeper)employee;
                            if (zooKeeper.HasAnimalExperience(animal))
                            {
                                zooKeeper.FeedAnimal(animal);
                                break;
                            }
                        }
                    }

                }
            }
        }

        public void HealAnimals()
        {
            foreach (Enclosure enclosure in Enclosures)
            {
                foreach (Animal animal in enclosure.Animals)
                {
                    foreach (IEmployee employee in Employees)
                    {
                        if (employee is Veterinarian)
                        {
                            Veterinarian veterinarian = (Veterinarian)employee;
                            if (veterinarian.HasAnimalExperience(animal))
                            {
                                veterinarian.HealAnimal(animal);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
