using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYRIDE_HW_2
{

    public class Ride
    {
        public Location startLocation { get; set; }
        public Location endLocation { get; set; }
        public int price { get; private set; }
        public Driver driver { get; private set; }
        public Passenger passenger { get; private set; }

        public Ride()
        {
            startLocation = new Location();
            endLocation = new Location();
            price = 0;
            driver = new Driver();
            passenger = new Passenger();
        }
        public Ride(Location startLocation, Location endLocation, int price, Driver driver, Passenger passenger)
        {
            this.startLocation = startLocation;
            this.endLocation = endLocation;
            this.price = price;
            this.driver = driver;
            this.passenger = passenger;
        }

        public void assignPassenger(Passenger passenger)
        {
            this.passenger = passenger;
        }

        public void assignDriver(Driver d)
        {
            if(d.availability == true)
            {
               driver = d;
            }
        }

        public void getLocations()
        {
            Console.Write("\t\tEnter start location coordinates (latitude, longitude): ");
            Console.ForegroundColor = ConsoleColor.Green;
            float startLat = float.Parse(Console.ReadLine());
            float startLng = float.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Black;
            this.startLocation = new Location(startLat, startLng);

            Console.Write("\t\tEnter end location coordinates (latitude, longitude): ");
            Console.ForegroundColor = ConsoleColor.Green;
            float endLat = float.Parse(Console.ReadLine());
            float endLng = float.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Black;
            this.endLocation = new Location(endLat, endLng);
        }

        public void calculatePrice(Vehicle v)
        {

            float distance = this.startLocation.DistanceTo(this.endLocation);
            float fuelPrice = 275.3F; // hardcoded petrol price per liter
            int fuelAverage = 0;  
            float commissionRate = 0.00F;

            if (v.type == "Bike")
            {
                fuelAverage = 50;
                commissionRate = 0.05F;
            }
            else if (v.type == "Rickshaw")
            {
                fuelAverage = 35;
                commissionRate = 0.1F;
            }
            else if (v.type == "Car")
            {
                fuelAverage = 15;
                commissionRate = 0.2F;
            }
            float compnayCommission = distance * commissionRate;
            this.price = (int)Math.Round((distance * fuelPrice) / fuelAverage + compnayCommission);
            Console.WriteLine($"\t\tPrice of the ride is: {this.price} pkr");

            // Console.WriteLine($"Distance: {distance} \n Average fuel: {fuelAverage} \n Company Commision: {compnayCommission}\n Price: {this.price}");
        }

        public void giveRating()
        {
            Console.Write("\n\t\tHow was the ride? Rate the driver from 1 to 5 : ");
            Console.ForegroundColor = ConsoleColor.Green;
            int driverRating = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Black;

            if (driverRating >= 1 && driverRating <= 5)
            {
                driver.rating.Add(driverRating);
            }
            else
            {
                Console.WriteLine("Invalid Rating! Please Enter Again!");

                giveRating();
            }
        }
    }

}
