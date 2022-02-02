using Microsoft.AspNetCore.Mvc;
using StudentsController.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace StudentsController.Services
{
    public class FileParser
    {
        private static string PATH = "./Data/students.csv";
        public static List<Student> RetrieveStudents()
        {
            List<Student> students = new List<Student>();
            using (var stream = new StreamReader(File.OpenRead(PATH)))
            {
                string line = null;
                while ((line = stream.ReadLine()) != null)
                {
                    string[] student = line.Split(',');
                    var st = new Student
                    {
                        FirstName = student[0],
                        LastName = student[1],
                        IndexNumber = student[2],
                        DateOfBirth = student[3],
                        Study = student[4],
                        Mode = student[5],
                        Email = student[6],
                        FatherName = student[7],
                        MotherName = student[8]
                    };
                    students.Add(st);
                }
            }
            return students;
        }

        public static IActionResult RetrieveStudent(string indexNumber)
        {
            Student student = FindStudentInList(RetrieveStudents(), indexNumber);
            return student == null ? Result.NotFoundStudent(indexNumber) : Result.RetrievedStudent(student);
        }

        public static IActionResult UpdateStudent(string indexNumber, Student sUpdate)
        {
            Student student = ModifyAndSaveStudent(RetrieveStudents(), indexNumber, sUpdate);
            return student == null ? Result.NotFoundStudent(indexNumber) : Result.RetrievedStudent(student);
        }

        public static IActionResult AddStudent(Student student)
        {
            if (Check(student.IndexNumber)) return Result.NotUniqueIndex(student.IndexNumber);
            if (!student.DataIsFulfilled()) return Result.NotFulfilled();
            List<Student> list = RetrieveStudents();
            list.Add(student);
            SaveStudentsToFile(list);
            return Result.StudentAdded(student.IndexNumber);
        }

        public static IActionResult DeleteStudent(string indexNumber)
        {
            if (!Check(indexNumber)) return Result.NotFoundStudent(indexNumber);
            RemoveAndSave(indexNumber);
            return Result.StudentDeleted(indexNumber);
        }

        private static Student FindStudentInList(List<Student> students, string indexNumber)
        {
            Student student = null;
            foreach (Student st in students)
            {
                if (st.IndexNumber == indexNumber) return st;
            }
            return student;
        }


        private static void RemoveAndSave(string index)
        {
            List<Student> students = RetrieveStudents();
            foreach (Student st in students)
            {
                if (st.IndexNumber == index)
                {
                    students.Remove(st);
                    SaveStudentsToFile(students);
                    break;
                }
            }
        }

        private static Student ModifyAndSaveStudent(List<Student> students, string indexNumber, Student sUpdate)
        {
            foreach (Student st in students)
            {
                if (st.IndexNumber == indexNumber)
                {
                    st.Modify(sUpdate);
                    SaveStudentsToFile(students);
                    return st;
                }
            }
            return null;
        }


        private static void SaveStudentsToFile(List<Student> students)
        {
            File.Delete(PATH);
            using (var file = new StreamWriter(PATH, true))
            {
                foreach (Student st in students)
                {
                    file.WriteLine(st.ToCsvFormat());
                }
            }
        }

        private static bool Check(string index)
        {
            if (string.IsNullOrEmpty(index)) return true;
            Regex regex = new Regex(@"^s[0-9]+$");
            Match match = regex.Match(index);
            if (!match.Success) return true;

            foreach (Student st in RetrieveStudents())
            {
                if (st.IndexNumber == index) return true;
            }
            return false;
        }
    }
}
