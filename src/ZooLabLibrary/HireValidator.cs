using System;
using System.Collections.Generic;

namespace ZooLabLibrary
{
    public abstract class HireValidator : IHireValidator
    {
        public abstract void ValidateEmployee(IEmployee employee, Zoo zoo);
    }
}
