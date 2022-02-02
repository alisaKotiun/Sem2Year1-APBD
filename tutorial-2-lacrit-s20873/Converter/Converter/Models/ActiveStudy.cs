using System;
using System.Text.Json.Serialization;

namespace Converter.Models
{
    public class ActiveStudy
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("numberOfStudents")]
        public int NumberOfStudents{ get; set; }

        public override bool Equals(object obj)
        {
            return obj is ActiveStudy study &&
                   Name == study.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
    }
}
