using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class FireTruck
    {
        public int IdFireTruck { get; set; }
        public string OperationalNumber { get; set; }
        public bool SpecialEquipment { get; set; }
        public virtual ICollection<FireTruckAction> FireTruckActions { get; set; }
    }
}
