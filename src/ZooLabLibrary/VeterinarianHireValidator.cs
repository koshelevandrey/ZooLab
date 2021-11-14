using System;
using System.Collections.Generic;

namespace ZooLabLibrary
{
    public class VeterinarianHireValidator : HireValidator
    {
        public override List<Exception> ValidateEmployee(IEmployee employee, Zoo zoo)
        {
            List<Exception> errors = new List<Exception>();

            if (!(employee is Veterinarian))
            {
                errors.Add(new Exception($"Employee {employee.FirstName} {employee.LastName} " +
                    "must be veterinarian to be validated with VeterinarianHireValidator"));
                return errors;
            }

            Veterinarian veterinarian = (Veterinarian)employee;

            // Get all types of animals in this zoo
            List<string> zooAnimalsTypes = zoo.GetAnimalTypes();

            // Check if veterinarian has experience with all types of animals in zoo
            foreach (string animalType in zooAnimalsTypes)
            {
                if (!veterinarian.AnimalExperiences.Contains(animalType))
                {
                    errors.Add(new NoNeededExperienceException($"Veterinarian {employee.FirstName} {employee.LastName} " +
                        $"must have experience at working with {animalType}"));
                    break;
                }
            }

            return errors;
        }
    }
}
