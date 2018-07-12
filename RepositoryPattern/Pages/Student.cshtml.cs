using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RepositoryPattern.Data;
using RepositoryPattern.Service.Interface;

namespace RepositoryPattern.Pages
{
    public class StudentModel : PageModel
    {
        private readonly IStudentService _studentService;
        public StudentModel(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [BindProperty]
        public IEnumerable<Student> Student { get; set; }
        public void OnGet()
        {
            Student = _studentService.GetAll();
        }
    }
}