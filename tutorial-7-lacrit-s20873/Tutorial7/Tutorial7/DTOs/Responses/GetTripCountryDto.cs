using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tutorial7.DTOs.Responses
{
    public class GetTripCountryDto
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }
    }
}
