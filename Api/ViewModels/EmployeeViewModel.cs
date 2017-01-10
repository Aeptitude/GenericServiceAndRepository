using Models;

namespace Api.ViewModels
{
    public class EmployeeViewModel
    {
        public string FirstName { get; set; }

        public string Surname { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
