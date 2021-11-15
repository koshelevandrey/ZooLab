using System;

namespace ZooLabLibrary
{
    public class HireValidatorProvider
    {
        public IHireValidator GetHireValidator(IEmployee employee)
        {
            if (employee is ZooKeeper)
            {
                return new ZooKeeperHireValidator();
            }
            else if (employee is Veterinarian)
            {
                return new VeterinarianHireValidator();
            }
            throw new Exception($"No available HireValidator for {employee.GetType().Name} class");
        }
    }
}
