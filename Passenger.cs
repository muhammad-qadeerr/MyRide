using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYRIDE_HW_2
{
    public class Passenger
    {
        public string passengerName { get; set; }
        public string passengerPhNo { get; set; }

        public Passenger()
        {
            passengerName = passengerPhNo = "";
        }
        public Passenger(string pName, string PhNo)
        {
            passengerName = pName;
            passengerPhNo = PhNo;
        }
    }


}
