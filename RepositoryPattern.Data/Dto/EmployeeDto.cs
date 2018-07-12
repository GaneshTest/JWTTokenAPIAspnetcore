using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryPattern.Data.Dto
{
    public class EmployeeDto
    {

        public int EmployeeId { get; set; }
        public string Name { get; set; }

        public int CityId { get; set; }

        public string CityName { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }


    }
}
