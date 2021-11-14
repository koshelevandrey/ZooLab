using System;

namespace ZooLabLibrary
{
    public class HireValidatorProvider
    {
        public HireValidator GetHireValidator(IEmployee employee)
        {
            if (employee is ZooKeeper)
            {
                return new ZooKeeperHireValidator();
            }
            else
            {
                return new VeterinarianHireValidator();
            }
            //throw new Exception($"No available HireValidator for {employee.GetType().Name} class");
        }
    }
}
