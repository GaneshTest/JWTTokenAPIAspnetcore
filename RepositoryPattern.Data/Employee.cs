using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryPattern.Data
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(Cities))]
        public int CityId { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }

        public virtual Cities Cities { get; set; }
    }
}
