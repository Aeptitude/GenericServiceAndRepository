using System.Collections.Generic;
using TestingGenerics.Models.Interfaces;

namespace TestingGenerics.Models
{
    public class Department : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
