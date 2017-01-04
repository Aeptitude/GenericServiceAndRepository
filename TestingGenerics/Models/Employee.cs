using System.ComponentModel.DataAnnotations.Schema;
using TestingGenerics.Models.Interfaces;

namespace TestingGenerics.Models
{
    public class Employee : IEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}
