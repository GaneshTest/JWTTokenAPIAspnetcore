using RepositoryPattern.Data;
using RepositoryPattern.Repository.Interface;
using RepositoryPattern.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryPattern.Service
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Student> GetAll()
        {
            return _unitOfWork.StudentRepository.Get();
        }
    }
}
