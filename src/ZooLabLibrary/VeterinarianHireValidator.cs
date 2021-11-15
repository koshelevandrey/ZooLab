using System;
using System.Collections.Generic;

namespace ZooLabLibrary
{
    public class VeterinarianHireValidator : HireValidator
    {
        public override void ValidateEmployee(IEmployee employee, Zoo zoo)
        {
            List<Exception> errors = new List<Exception>();

            if (!(employee is Veterinarian))
            {
                throw new Exception($"Employee {employee.FirstName} {employee.LastName} " +
                    "must be veterinarian to be validated with VeterinarianHireValidator");
            }

            Veterinarian veterinarian = (Veterinarian)employee;

            // Get all types of animals in this zoo
            List<string> zooAnimalsTypes = zoo.GetAnimalTypes();

            // Check if veterinarian has experience with all types of animals in zoo
            foreach (string animalType in zooAnimalsTypes)
            {
                if (!veterinarian.AnimalExperiences.Contains(animalType))
                {
                    throw new NoNeededExperienceException($"Veterinarian {employee.FirstName} {employee.LastName} " +
                        $"must have experience at working with {animalType}");
                }
            }
        }
    }
}
