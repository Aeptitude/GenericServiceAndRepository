using System;
using Domain.Calculators.Interfaces;
using Models.Interfaces;

namespace Domain.Calculators
{
    public class EmployeeSalaryCalculator : ISalaryCalculator
    {
        public decimal CalculateSalary(ISalaryValues values)
        {
            if (!values.AreValid()) throw new ArgumentNullException();

            return values.Age * values.YearsOfService;
        }
    }
}
