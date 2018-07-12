using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Repository.Interface;
using data = RepositoryPattern.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RepositoryPattern
{
    [Route("api/[controller]")]
    public class Employee : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public Employee(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<data.Dto.EmployeeDto> Get()
        {
            return _unitOfWork.EmployeeRepository.Get().Select(x => new data.Dto.EmployeeDto
            {

                CityName = x.Cities.CityName,
                EmployeeId = x.EmployeeId,
                Department = x.Department,
                Gender = x.Gender,
                Name = x.Name,
                CityId = x.CityId,
            }).ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]data.Employee employee)
        {
            _unitOfWork.EmployeeRepository.Insert(employee);
        }

        // PUT api/<controller>/5
       // [HttpPut("{id}")]
        public void Put([FromBody]data.Employee employee)
        {
            _unitOfWork.EmployeeRepository.Update(employee);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _unitOfWork.EmployeeRepository.Delete(id);
        }
    }
}
