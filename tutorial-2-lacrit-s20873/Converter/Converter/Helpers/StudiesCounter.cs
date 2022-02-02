using Converter.Models;
using System.Collections.Generic;

namespace Converter.Helpers
{
    //used to identify unique activeStudies and count them
    public class StudiesCounter
    {
        public static HashSet<ActiveStudy> CountNumberOfStudies(HashSet<Student> students)
        {
            var activeStudies = new HashSet<ActiveStudy>();

            foreach(Student student in students)
            {
                ActiveStudy activeStudy = new ActiveStudy
                {
                    Name = student.StudyName.Name,
                    NumberOfStudents = 0
                };
                activeStudies.Add(activeStudy);
            }

            foreach (Student student in students)
            {
                foreach(ActiveStudy activeStudy in activeStudies)
                {
                    if (activeStudy.Name == student.StudyName.Name)
                        activeStudy.NumberOfStudents++;
                }
            }

            return activeStudies;
        }
    }
}
