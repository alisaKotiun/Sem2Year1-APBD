using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial8.Models;

namespace Tutorial8.DTOs.Request
{
    public class PrescriptionRequestDto
    {
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }
        public ICollection<int> Medicaments { get; set; }
    }
}
