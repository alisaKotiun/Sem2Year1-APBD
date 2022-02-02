using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Converter.Models
{
    public class Study
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("mode")]
        public string Mode { get; set; }
    }
}
