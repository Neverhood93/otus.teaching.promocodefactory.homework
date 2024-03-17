using Otus.Teaching.PromoCodeFactory.Core.Domain.Administration;
using System.Collections.Generic;
using System;

namespace Otus.Teaching.PromoCodeFactory.WebHost.Models
{
    public class EmployeeHelper
    {
        public Employee GetEmployeeFromInputModel(InputEmployeeModel model)
        {
            Employee newEmployee = new Employee();

            newEmployee.FirstName = model.FirstName;
            newEmployee.LastName = model.LastName;
            newEmployee.Email = model.Email;
            newEmployee.AppliedPromocodesCount = model.AppliedPromocodesCount;

            return newEmployee;
        }
    }
}
