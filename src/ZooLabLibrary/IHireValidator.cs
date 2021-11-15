using System;
using System.Collections.Generic;

namespace ZooLabLibrary
{
    public interface IHireValidator
    {
        void ValidateEmployee(IEmployee employee, Zoo zoo);
    }
}
