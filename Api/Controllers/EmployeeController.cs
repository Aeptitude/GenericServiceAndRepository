using System.Collections.Generic;
using System.Linq;
using Api.ViewModels;
using Domain;

namespace Api.Controllers
{
    public class EmployeeController
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
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
