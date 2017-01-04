using System.Collections.Generic;
using Models.Interfaces;

namespace Models
{
    public class Department : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
