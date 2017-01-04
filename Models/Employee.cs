using Models.Interfaces;

namespace Models
{
    public class Employee : IEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}
