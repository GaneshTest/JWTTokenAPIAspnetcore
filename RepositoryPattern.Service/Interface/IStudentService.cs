using RepositoryPattern.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryPattern.Service.Interface
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAll();
    }
}
