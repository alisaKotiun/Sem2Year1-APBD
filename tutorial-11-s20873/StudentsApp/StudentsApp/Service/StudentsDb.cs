using StudentsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsApp.Service
{
    public class StudentsDb
    {
        public List<Student> _students = new List<Student>();
        private static string lastColumn;
        private static bool asc = true;

        public StudentsDb()
        {
            _students.Add(
                new Student
                {
                    IdStudent = 1,
                    Avatar = "https://shutniki.club/wp-content/uploads/2019/12/v1-babay29.png",
                    FirstName = "Alisa",
                    LastName = "Kotiun",
                    BirthDate = new DateTime(2002, 04, 13),
                    Studies = "Informatyka"
                });
            _students.Add(
                new Student
                {
                    IdStudent = 2,
                    Avatar = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ3zM8i6G8Yf5GcoqnhFBV6QwvPeK9BvJo7KR7nsTNPlTGK5ighb8uLWwVNoPyCfKrF5tc&usqp=CAU",
                    FirstName = "Sofiia",
                    LastName = "Perelyhina",
                    BirthDate = new DateTime(2001, 04, 11),
                    Studies = "Informatyka"
                });
            _students.Add(
                new Student
                {
                    IdStudent = 3,
                    Avatar = "https://shutniki.club/wp-content/uploads/2019/12/0aeb27b230deae824f3d1bce090bc2e9.png",
                    FirstName = "Anastasia",
                    LastName = "Mendel",
                    BirthDate = new DateTime(2003, 01, 19),
                    Studies = "Grafika"
                });
        }

        public List<Student> GetStudents()
        {
            return _students;
        }
        public void SortStudents(string columnName)
        {
            if (lastColumn == columnName)
            {
                Sort(asc, columnName);
                asc = !asc;
            }
            else
            {
                Sort(true, columnName);
            }
            lastColumn = columnName;
        }

        private void Sort(bool asc, string columnName)
        {
            switch (columnName)
            {
                case "LastName":
                    _students = (asc ? _students.OrderBy(s => s.LastName) : _students.OrderByDescending(s => s.LastName)).ToList();
                    break;
                case "BirthDate":
                    _students = (asc ? _students.OrderBy(s => s.BirthDate) : _students.OrderByDescending(s => s.BirthDate)).ToList();
                    break;
                case "Studies":
                    _students = (asc ? _students.OrderBy(s => s.Studies) : _students.OrderByDescending(s => s.Studies)).ToList();
                    break;
                default:
                    _students = (asc ? _students.OrderBy(s => s.FirstName) : _students.OrderByDescending(s => s.FirstName)).ToList();
                    break;
            }
        }

        public void DeleteStudent(int id, bool conf)
        {
            if (conf)
            {
                _students = _students.Where(s => s.IdStudent != id).ToList();
            }
        }

        public Student GetStudent(int id)
        {
            return _students.SingleOrDefault(s => s.IdStudent == id);
        }
    }
}
