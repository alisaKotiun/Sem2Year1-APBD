using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Converter.Models
{
    public class Student
    {
        private string index;
        private string date;
        [JsonPropertyName("indexNumber")]
        public string IndexNumber {
            get { return index; }
            set { index = "s" + value; }
        }
        [JsonPropertyName("fname")]
        public string FirstName { get; set; }
        [JsonPropertyName("lname")]
        public string LastName { get; set; }
        [JsonPropertyName("birthdate")]
        public string BirthDate {
            get { return date; }
            set { DateTime oDate = DateTime.Parse(value);
                string day = oDate.Day < 10 ? "0" + oDate.Day : "" + oDate.Day;
                string month = oDate.Month < 10 ? "0" + oDate.Month : "" + oDate.Month;
                date = day + "." + month + "." + oDate.Year; } 
        }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("mothersName")]
        public string MothersName { get; set; }
        [JsonPropertyName("fathersName")]
        public string FathersName { get; set; }
        [JsonPropertyName("studies")]
        public Study StudyName { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   IndexNumber == student.IndexNumber &&
                   FirstName == student.FirstName &&
                   LastName == student.LastName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IndexNumber, FirstName, LastName);
        }

    }
}
