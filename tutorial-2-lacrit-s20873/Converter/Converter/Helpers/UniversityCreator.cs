using Converter.Models;
using System.IO;
using System.Text.Json.Serialization;

namespace Converter.Helpers
{
    //used to create all properties of university and university itself
    public class UniversityCreator
    {
        public static UniversityWrapper CreateUniversity(FileInfo file)
        {
            var students = FileParser.ParseFileFromCsv(file);
            var activeStudies = StudiesCounter.CountNumberOfStudies(students);


            University university = new University
            {
                Author = "Alisa Kotiun",
                Students = students,
                ActiveStudies = activeStudies,
                Date = null
            };

            UniversityWrapper universityWrapper = new UniversityWrapper
            {
                University = university
        };
            return universityWrapper;
        }
    }
}
