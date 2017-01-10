using System;
using System.Threading;
using Data.Interfaces;
using Domain.Calculators.Interfaces;
using Models;

namespace Domain
{
    public class EmployeeService : GenericService<Employee>
    {
        public ISalaryCalculator Calculator { get; set; }

        public EmployeeService(IUnitOfWork unitOfWork, ISalaryCalculator calculator) : base(unitOfWork)
        {
            if(calculator != null) Calculator = calculator;
        }

        public override void Update(Employee employee)
        {
            if (Calculator == null) throw new ArgumentNullException();

            employee.Salary = Calculator.CalculateSalary(employee);
            base.Update(employee);
        }
    }
}
