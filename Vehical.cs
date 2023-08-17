using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYRIDE_HW_2
{
    public class Vehicle
    {
        public string type { get; set; }
        public string model { get; set; }
        public string licensePlate { get; set; }

        public Vehicle()
        {
            type = "";
            model = "";
            licensePlate = "";
        }
        public Vehicle(string t, string m, string lp)
        {
            type = t;
            model = m;
            licensePlate = lp;
        }
    }
}

