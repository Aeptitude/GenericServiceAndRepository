using System.Collections.Generic;
using System.Linq;
using TestingGenerics.Domain.Interfaces;
using TestingGenerics.Models;
using TestingGenerics.ViewModels;

namespace TestingGenerics.Controllers
{
    public class EmployeeController
    {
        private readonly IService<Employee> _employeeService;

        public EmployeeController(IService<Employee> employeeService)
        {
            _employeeService = employeeService;
        }

        public IEnumerable<EmployeeViewModel> GetAll()
        {
            return _employeeService.GetAll()
                .Select(e => e.GetInstance())
                .Select(e => new EmployeeViewModel
                {
                    FirstName = e.FirstName,
                    Surname = e.Surname,
                    DepartmentId = e.DepartmentId
                });
        }

        public EmployeeViewModel GetById(int id)
        {
            var employee = _employeeService.GetById(id).GetInstance();

            return new EmployeeViewModel
            {
                FirstName = employee.FirstName,
                Surname = employee.Surname,
                DepartmentId = employee.DepartmentId
            };
        }
    }
}
