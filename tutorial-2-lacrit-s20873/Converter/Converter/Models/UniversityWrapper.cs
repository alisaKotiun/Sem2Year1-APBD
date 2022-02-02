using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Converter.Models
{
    public class UniversityWrapper
    {
        [JsonPropertyName("university")]
        public University University { get; set; }
    }
}
