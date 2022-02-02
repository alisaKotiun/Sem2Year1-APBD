using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsController.Models
{
    public class Result
    {
        public static IActionResult NotFoundStudent(string index)
        {
            return new NotFoundObjectResult("Student " + index + " doesn't exist or the index is invalid");
        }

        public static IActionResult RetrievedStudent(Student student)
        {
            return new OkObjectResult(student);
        }

        public static IActionResult NotUniqueIndex(string index)
        {
            return new NotFoundObjectResult("Student " + index + " already exists or the index is invalid");
        }

        public static IActionResult StudentDeleted(string index)
        {
            return new OkObjectResult("Student " + index + " is successfully deleted");
        }

        public static IActionResult NotFulfilled()
        {
            return new NotFoundObjectResult("Data is not fulfilled. Student can't be added");
        }

        public static IActionResult StudentAdded(string index)
        {
            return new OkObjectResult("Student " + index + " is successfully added");
        }
    }
}
