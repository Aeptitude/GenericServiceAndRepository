using System;
using Domain.Calculators.Interfaces;
using Models.Interfaces;

namespace Domain.Calculators
{
    public class ManagerSalaryCalculator : ISalaryCalculator
    {
        private const decimal Bonus = 1000M;

        public decimal CalculateSalary(ISalaryValues values)
        {
            if (!values.AreValid()) throw new ArgumentNullException();

            return values.Age * values.YearsOfService + Bonus;
        }
    }
}
