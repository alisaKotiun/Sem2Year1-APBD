﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class Firefighter
    {
        public int IdFirefighter { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<FirefighterAction> FirefighterActions { get; set; }

    }
}
