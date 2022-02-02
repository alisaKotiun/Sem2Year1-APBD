using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Tutorial7.DTOs.Responses;

namespace Tutorial7.DTOs.Response
{
    public class GetTripDto
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("Description")]
        public string Description { get; set; }
        [JsonPropertyName("DateFrom")]
        public DateTime DateFrom { get; set; }
        [JsonPropertyName("DateTo")]
        public DateTime DateTo { get; set; }
        [JsonPropertyName("MaxPeople")]
        public int MaxPeople { get; set; }
        [JsonPropertyName("Countries")]
        public IEnumerable<GetTripCountryDto> Countries { get; set; }
        [JsonPropertyName("Clients")]
        public IEnumerable<GetTripClientDto> Clients { get; set; }

    }
}
