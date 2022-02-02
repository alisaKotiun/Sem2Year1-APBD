using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Converter.Models
{
    public class University
    {
        private string date;
        [JsonPropertyName("createdAt")]
        public string Date {
            get { return date; }
            set
            {

                DateTime oDate = (string.IsNullOrEmpty(value) ? DateTime.Now : DateTime.Parse(value));
                string day = oDate.Day < 10 ? "0" + oDate.Day : "" + oDate.Day;
                string month = oDate.Month < 10 ? "0" + oDate.Month : "" + oDate.Month;
                date = day + "." + month + "." + oDate.Year;
            }
        }
        [JsonPropertyName("author")]
        public string Author { get; set; }
        [JsonPropertyName("students")]
        public HashSet<Student> Students { get; set; }
        [JsonPropertyName("activeStudies")]
        public HashSet<ActiveStudy> ActiveStudies { get; set; }
    }
}
