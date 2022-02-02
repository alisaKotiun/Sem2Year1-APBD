using Converter.Models;
using System.Collections.Generic;
using System.IO;
using System;

namespace Converter.Helpers
{
    //used to analyze the file and extract HashSet of students
    public static class FileParser
    {
        public static HashSet<Student> ParseFileFromCsv(FileInfo file)
        {
            HashSet<Student> students = new HashSet<Student>();
            using (var stream = new StreamReader(file.OpenRead()))
            {
                string line = null;
                while ((line = stream.ReadLine()) != null)
                {
                    string[] student = line.Split(',');
                    if (student.Length != 9)
                    {
                        ErrorReporter.ReportOnError(new Exception("Invalid data about a student:\n" + line));
                    }
                    else
                    {
                        if (check(student))
                        {
                            ErrorReporter.ReportOnError(new Exception("Some fields are empty:\n" + line));
                            continue;
                        }
                        var st = new Student
                        {
                            FirstName = student[0],
                            LastName = student[1],
                            StudyName = new Study
                            {
                                Name = student[2],
                                Mode = student[3]
                            },
                            IndexNumber = student[4],
                            BirthDate = student[5],
                            Email = student[6],
                            MothersName = student[7],
                            FathersName = student[8]
                        };
                        students.Add(st);
                    }
                }
            }
            return students;
        }
        private static bool check(string [] student) //check if each column is not empty
        {
            foreach (string st in student)
            {
                if (string.IsNullOrEmpty(st)) return true;
            }
            return false;
        }
    }
}
