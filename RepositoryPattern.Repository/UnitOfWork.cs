using RepositoryPattern.Data;
using RepositoryPattern.Data.DAL;
using RepositoryPattern.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryPattern.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        internal ApplicationDbContext _applicationDbContext;
        private Repository<Student> _studentRepository;

        private Repository<NotificationLog> _notificationLogRepository;
        private Repository<NotificationLogUser> _notificationLogUserRepository;

        private Repository<Employee> _employeeRepository;

        private Repository<Cities> _citiesRepository;
        public UnitOfWork(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }
        public IRepository<Student> StudentRepository
        {
            get
            {
                return _studentRepository = _studentRepository ?? new Repository<Student>(_applicationDbContext);
            }
        }
        public IRepository<NotificationLog> NotificationLogRepository
        {
            get
            {
                return _notificationLogRepository = _notificationLogRepository ?? new Repository<NotificationLog>(_applicationDbContext);
            }
        }
        public IRepository<NotificationLogUser> NotificationLogUserRepository
        {
            get
            {
                return _notificationLogUserRepository = _notificationLogUserRepository ?? new Repository<NotificationLogUser>(_applicationDbContext);
            }
        }
        public IRepository<Employee> EmployeeRepository
        {
            get
            {
                return _employeeRepository = _employeeRepository ?? new Repository<Employee>(_applicationDbContext);
            }
        }
        public IRepository<Cities> CitiesRepository
        {
            get
            {
                return _citiesRepository = _citiesRepository ?? new Repository<Cities>(_applicationDbContext);
            }
        }
        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _applicationDbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
