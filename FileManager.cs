using MYRIDE_HW_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MYRIDE_HW_2
{
    public class FileManager
    {
        public static void WriteInDriverFile(Driver d)
        {
            StreamWriter sw = new StreamWriter("Drivers.txt", append:true);

            sw.WriteLine($"{d.id},{d.name},{d.age},{d.gender},{d.address},{d.phoneNumber},{d.currLocation.latitude},{d.currLocation.longitude},{d.vehical.type},{d.vehical.model},{d.vehical.licensePlate},{d.availability}");
        }

        public static Driver ReadDriversFromFile()
        {
            StreamReader sr = new StreamReader("Drivers.txt");
            string line = sr.ReadLine();
            var data = line.Split(',');
            sr.Close();
            Location l = new Location(float.Parse(data[6]), float.Parse(data[7]));
            Vehicle v = new Vehicle(data[8], data[9], data[10]);
            Driver d = new Driver
            {
                id = int.Parse(data[0]),
                name = data[1],
                age = int.Parse(data[3]),
                address = data[4],
                phoneNumber = data[5], currLocation = l, vehical = v, availability = bool.Parse(data[11])};

            return d;
        }
    }
}
