using RepositoryPattern.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryPattern.Repository.Interface
{
    public interface IUnitOfWork
    {
        IRepository<Student> StudentRepository { get; }
        IRepository<NotificationLog> NotificationLogRepository { get; }
        IRepository<NotificationLogUser> NotificationLogUserRepository { get; }
        IRepository<Employee> EmployeeRepository { get; }

        IRepository<Cities> CitiesRepository { get; }
        void Save();
    }
}
