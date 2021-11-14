using System;
using System.Collections.Generic;

namespace ZooLabLibrary
{
    public class ZooKeeperHireValidator : HireValidator
    {
        public override List<Exception> ValidateEmployee(IEmployee employee, Zoo zoo)
        {
            List<Exception> errors = new List<Exception>();

            if (!(employee is ZooKeeper))
            {
                errors.Add(new Exception($"Employee {employee.FirstName} {employee.LastName} " +
                    "must be zookeeper to be validated with ZooKeeperHireValidator"));
                return errors;
            }

            ZooKeeper zooKeeper = (ZooKeeper)employee;

            // Get all types of animals in this zoo
            List<string> zooAnimalsTypes = zoo.GetAnimalTypes();

            // Check if zookeeper has experience with all types of animals in zoo
            foreach (string animalType in zooAnimalsTypes)
            {
                if (!zooKeeper.AnimalExperiences.Contains(animalType))
                {
                    errors.Add(new NoNeededExperienceException($"Zookeeper {employee.FirstName} {employee.LastName} " +
                        $"must have experience at working with {animalType}"));
                    break;
                }
            }

            return errors;
        }
    }
}
