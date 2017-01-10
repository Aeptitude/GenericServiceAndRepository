using Models.Interfaces;

namespace Models
{
    public class Employee : IEntity, ISalaryValues
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public decimal Salary { get; set; }

        public int Age { get; set; }

        public int YearsOfService { get; set; }

        public bool AreValid()
        {
            return (Age > 0 && YearsOfService > 0);
        }
    }
}
