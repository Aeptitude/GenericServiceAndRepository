using Models.Interfaces;

namespace Domain.Calculators.Interfaces
{
    public interface ISalaryCalculator
    {
        decimal CalculateSalary(ISalaryValues values);
    }
}
