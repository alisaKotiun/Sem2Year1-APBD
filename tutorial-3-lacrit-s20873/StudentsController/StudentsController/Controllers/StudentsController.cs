using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsController.Models;
using StudentsController.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsController.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetStudents()
        {
            List<Student> students = FileParser.RetrieveStudents();
            return Ok(students);
        }

        [HttpGet("{indexNumber}")]
        public IActionResult GetStudent(string indexNumber)
        {
            return FileParser.RetrieveStudent(indexNumber);
        }

        [HttpPut("{indexNumber}")]
        public IActionResult UpdateStudent(string indexNumber, Student studentUpdate)
        {
            return FileParser.UpdateStudent(indexNumber, studentUpdate);
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            return FileParser.AddStudent(student);
        }

        [HttpDelete("{indexNumber}")]
        public IActionResult DeleteStudent(string indexNumber)
        {
            return FileParser.DeleteStudent(indexNumber);
        }
    }
}
