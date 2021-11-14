using System;
using System.Collections.Generic;

namespace ZooLabLibrary
{
    public abstract class HireValidator
    {
        public abstract List<Exception> ValidateEmployee(IEmployee employee, Zoo zoo);
    }
}
