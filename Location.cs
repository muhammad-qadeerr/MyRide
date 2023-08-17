using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYRIDE_HW_2
{
    public class Location
    {
        public float latitude { get; set; }
        public float longitude { get; set; }

        public Location()
        {
            latitude = 0.0F;
            longitude = 0.0F;
        }

        public Location(float la, float lo)
        {
            latitude = la;
            longitude = lo;
        }

        public void setLocation(float la, float lo)
        {
            latitude = la;
            longitude = lo;
        }

        public float DistanceTo(Location other) // Find the difference between two Euclidean distances.
        {
            float latDiff = latitude - other.latitude;
            float lonDiff = longitude - other.longitude;
            return (float)Math.Sqrt(latDiff * latDiff + lonDiff * lonDiff);
        }
    }
}
