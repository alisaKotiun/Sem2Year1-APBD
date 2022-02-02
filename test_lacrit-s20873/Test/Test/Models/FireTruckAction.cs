using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class FireTruckAction
    {
        public int IdFireTruckAction { get; set; }
        public int IdFireTruck { get; set; }
        public int IdAction { get; set; }


        public virtual FireTruck FireTruck { get; set; }
        public virtual Action Action { get; set; }

        public DateTime AssignmentDate { get; set; }
    }
}
