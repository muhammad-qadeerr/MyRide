using MYRIDE_HW_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYRIDE_HW_2
{
    public class Admin
    {
        public List<Driver> drivers { get; set; }

        public Admin()
        {
            drivers = new List<Driver>();
        }

        public void addDriver()
        {

            Console.Write("\t\tEnter ID: ");
            Console.ForegroundColor = ConsoleColor.Green;
            int driID = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("\t\tEnter Name: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("\t\tEnter Age: ");
            Console.ForegroundColor = ConsoleColor.Green;
            int age = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("\t\tEnter Gender: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string gender = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("\t\tEnter Address: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string address = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("\t\tEnter Vehical Type (Car, Bike, Rickshaw): ");
            Console.ForegroundColor = ConsoleColor.Green;
            string type = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("\t\tEnter Vehical Model: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string model = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("\t\tLicense Plate: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string licensePlate = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("\t\tEnter Phone Number: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string phoneNum = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("\t\tWhere do you live? (Latitude, Longitude): ");
            Console.ForegroundColor = ConsoleColor.Green;
            float lat = float.Parse(Console.ReadLine());
            float lon = float.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Black;
            Location currLocation = new Location(lat, lon);
            Vehicle vehicle = new Vehicle(type, model, licensePlate);
            bool addDriverAval = true;
            Driver driver = new Driver(driID, name, age, gender, address, phoneNum, currLocation, vehicle, addDriverAval);


            //FileManager.WriteInDriverFile(driver);
            StreamWriter sw = new StreamWriter("Drivers.txt", append: true);

            sw.WriteLine($"{driID},{name},{age},{gender},{address},{phoneNum},{currLocation.latitude},{currLocation.longitude},{vehicle.type},{vehicle.model},{vehicle.licensePlate},{addDriverAval}");
            sw.Close();


            Console.WriteLine("\n\t\tDriver added successfully!\n");
        }


        public void removeDriver(int idToRemove)
        {
            StreamReader sr = new StreamReader("Drivers.txt");
            StreamWriter sw = new StreamWriter("TempFile.txt");
            string line = sr.ReadLine();
            bool driverFound = false;

            while (line != null)
            {
                var lineData = line.Split(',');
                if (int.Parse(lineData[0]) != idToRemove)
                {
                    sw.WriteLine(line);
                }
                else
                {
                    driverFound = true;
                }

                line = sr.ReadLine();
            }

            sr.Close();
            sw.Close();

            if (driverFound)
            {
                File.Delete("Drivers.txt");
                File.Move("TempFile.txt", "Drivers.txt");
                Console.WriteLine("\n\t\tDriver removed successfully!\n");
            }
            else
            {
                File.Delete("TempFile.txt");
                Console.WriteLine("\n\t\tDriver not found!\n");
            }
        }
        public void updateDriver(int driverId)
        {
            bool driverFound = false;
            drivers = new List<Driver>();

            // Read existing drivers from file and add them to the list
            using (StreamReader sr = new StreamReader("Drivers.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    var lineData = line.Split(',');

                    //Console.WriteLine(lineData[0]);

                    Driver driver = new Driver();
                    driver.id = int.Parse(lineData[0]);
                    driver.name = lineData[1];
                    driver.age = int.Parse(lineData[2]);
                    driver.gender = lineData[3];
                    driver.address = lineData[4];
                    driver.phoneNumber = lineData[5];
                    driver.currLocation.latitude = float.Parse(lineData[6]);
                    driver.currLocation.longitude = float.Parse(lineData[7]);
                    driver.vehical.type = lineData[8];
                    driver.vehical.model = lineData[9];
                    driver.vehical.licensePlate = lineData[10];
                    driver.availability = bool.Parse(lineData[11]);

                    drivers.Add(driver);

                }
                sr.Close();
            }

            // Find the driver to update in the list
            foreach (Driver driver in drivers)
            {
                if (driver.id == driverId)
                {
                    driverFound = true;
                    Console.WriteLine($"\n\t\t--------------- Driver with ID {driver.id} exists ---------------------\n");

                    Console.WriteLine("\t\tSelect field to update: ");
                    Console.WriteLine("\t\t1. Name");
                    Console.WriteLine("\t\t2. Age");
                    Console.WriteLine("\t\t3. Gender");
                    Console.WriteLine("\t\t4. Address");
                    Console.WriteLine("\t\t5. Phone Number");
                    Console.WriteLine("\t\t6. Current Location (Latitude, Longitude)");
                    Console.WriteLine("\t\t7. Vehicle Type");
                    Console.WriteLine("\t\t8. Vehicle Model");
                    Console.WriteLine("\t\t9. Vehicle License Plate\n");
                    Console.Write("\t\tEnter 1 to 9 for updating an attribute: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    int updateChoice = int.Parse(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.Black;

                    switch (updateChoice)
                    {
                        case 1:
                            Console.Write("\t\tEnter New Name: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            driver.name = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                        case 2:
                            Console.Write("\t\t Enter New Age: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            driver.age = int.Parse(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                        case 3:
                            Console.Write("\t\tEnter New Gender: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            driver.gender = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                        case 4:
                            Console.Write("\t\tEnter New Address: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            driver.address = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                        case 5:
                            Console.Write("\t\tEnter New Phone Number: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            driver.phoneNumber = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                        case 6:
                            Console.Write("\t\tEnter New Current Location (Latitude,Longitude): ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            float newLat = float.Parse(Console.ReadLine());
                            float newLon = float.Parse(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.Black;
                            driver.currLocation.latitude = newLat;
                            driver.currLocation.longitude = newLon;
                            break;
                        case 7:
                            Console.Write("New Vehicle Type (Car, Bike, Rickshaw): ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            driver.vehical.type = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                        case 8:
                            Console.Write("New Vehicle Model: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            driver.vehical.model = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                        case 9:
                            Console.Write("New Vehicle License Plate: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            driver.vehical.licensePlate = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                        default:
                            Console.WriteLine("Invalid Updation Asked!");
                            break;
                    }
                    drivers.Add(driver);
                    StreamWriter sw = new StreamWriter("Drivers.txt");

                    foreach (Driver existingDriver in drivers)
                    {
                        sw.WriteLine($"{existingDriver.id},{existingDriver.name},{existingDriver.age},{existingDriver.gender},{existingDriver.address},{existingDriver.phoneNumber},{existingDriver.currLocation.latitude},{existingDriver.currLocation.longitude},{existingDriver.vehical.type},{existingDriver.vehical.model},{existingDriver.vehical.licensePlate},{existingDriver.availability}");

                    }
                    sw.Close();
                    Console.WriteLine("\n\t\tDriver Updated Successfully!\n");
                }

            }
            
        }
    

        public void searchDriver(int driverId)
        {
            StreamReader sr = new StreamReader("Drivers.txt");
            string line = sr.ReadLine();
            bool driverFound = false;

            while (line != null)
            {
                var lineData = line.Split(',');
                if (int.Parse(lineData[0]) == driverId)
                {
                    driverFound = true;
                    Console.WriteLine($"\n\t\t--------------- Search results for Driver with ID {driverId} ---------------------\n");
                    Console.WriteLine("Name\t\tAge\t\tGender\t\tV.Type\t\tV.Model\t\tV.License");
                    Console.WriteLine("--------------------------------------------------------------------------------------------------------");
                    Console.WriteLine($"{lineData[1]}\t\t{int.Parse(lineData[2])}\t\t{lineData[3]}\t\t{lineData[8]}\t\t{lineData[9]}\t\t{lineData[10]}");
                    Console.WriteLine("--------------------------------------------------------------------------------------------------------\n\n");
                }

                line = sr.ReadLine();
            }

            sr.Close();

            if (!driverFound)
            {
                Console.WriteLine("\n\t\tDriver not found!\n");
            }
        }
    }
}

