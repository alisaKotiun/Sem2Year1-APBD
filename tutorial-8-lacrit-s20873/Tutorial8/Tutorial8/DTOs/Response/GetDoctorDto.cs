﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial8.DTOs.Response
{
    public class GetDoctorDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IEnumerable<GetPrescriptionDto> Prescriptions { get; set; }
    }
}
