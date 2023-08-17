using System;
using System.Reflection;
using System.Xml.Linq;

namespace MYRIDE_HW_2
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear(); // This line is used to clear the console and update the background color
            Console.ForegroundColor = ConsoleColor.Black;

            

            Driver d = new Driver();
            Location l = new Location();
            Passenger p = new Passenger();
            Ride r = new Ride();
            Vehicle v = new Vehicle();
            Admin a = new Admin();

        Start:
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine("\t\t\t*** WELCOME TO MYRIDE ***\t\t\t");
            Console.WriteLine("----------------------------------------------------------------------------------");


            Console.WriteLine("\t\t1. Book a Ride\n\t\t2. Enter as Driver\n\t\t3. Enter as Admin\n\n");
            Console.Write("\t\tPress 1 to 3 to select an option: ");
            Console.ForegroundColor = ConsoleColor.Green;
            int option = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Black;



            if (option == 1)
            {

                Console.WriteLine("\n\tBOOK A RIDE\n");
                Console.WriteLine("\t\t\tEntering as Passenger ...!\n");


                Console.Write("\t\tEnter Name: ");
                Console.ForegroundColor = ConsoleColor.Green;
                p.passengerName = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Black;

                Console.Write("\t\tEnter Phone Number: ");
                Console.ForegroundColor = ConsoleColor.Green;
                p.passengerPhNo = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Black;

                r.getLocations();

                Console.Write("\t\tEnter Ride type (Bike, Car or Rickshaw):");
                Console.ForegroundColor = ConsoleColor.Green;
                v.type = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Black;

                Console.WriteLine("\n\t ------------------------- THANK YOU ---------------------------\n\n");

                r.calculatePrice(v);

                Console.Write("\n\t\tEnter ‘Y/y’ if you want to Book the ride, enter ‘N/n’ if you want to cancel operation: ");
                Console.ForegroundColor = ConsoleColor.Green;
                char rideConfirmation = char.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Black;
                if (rideConfirmation == 'Y' || rideConfirmation == 'y')
                {
                    Console.WriteLine("\n\t\t\t Happy Travel :)\t");
                }
                r.giveRating();

            }
            else if (option == 2)
            {
                Console.WriteLine("\n\tENTER AS DRIVER\n");
                Console.WriteLine("\t\t\tEntering as Driver ...!\n");
            LoginRegister:
                Console.Write("\t\tEnter 1 to LOGIN and 2 to REGISTER as new Driver: ");
                Console.ForegroundColor = ConsoleColor.Green;
                int entryChoice = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Black;
                if (entryChoice == 1)
                {
                    Console.WriteLine("\n\t\t\tEnter ID and name to LOG IN as Driver ...!\n");
                    Console.Write("\t\tEnter ID: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    int driverID = int.Parse(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write("\t\tEnter Name: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    d.name = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Black;

                    //Driver driver = a.drivers.Find(d => d.id == driverID);
                    StreamReader sr = new StreamReader("Drivers.txt");
                    string line = sr.ReadLine();
                    var lineData = line.Split(',');
                    sr.Close();
                    Location l1 = new Location(float.Parse(lineData[6]), float.Parse(lineData[7]));
                    Vehicle v1 = new Vehicle(lineData[8], lineData[9], lineData[10]);
                    Driver d1 = new Driver(int.Parse(lineData[0]), lineData[1], int.Parse(lineData[2]), lineData[3], lineData[4], lineData[5], l1, v1, bool.Parse(lineData[11]));


                    if (int.Parse(lineData[0]) != driverID)
                    {
                        Console.WriteLine("\n\t\tYou are not registered with MYRIDE, Please enter 2 to register yourself!\n");
                        goto LoginRegister;
                    }
                    else
                    {
                        Console.WriteLine($"\n\t\tHello {lineData[1]}!\n");
                        Console.Write("\t\tEnter your current Location (Latitude, Longitude): ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        float currLat = float.Parse(Console.ReadLine());
                        float currLon = float.Parse(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Black;

                        d1.currLocation.setLocation(currLat, currLon);
                     
                        Console.WriteLine("\t\tCurrent Location Set Successfully!\n");
                    DriverMenu:
                        Console.WriteLine("\t\t1. Change Availability\n\t\t2. Change Location\n\t\t3. Exit as Driver\n\n");
                        Console.Write("\t\tEnter 1 to 3 for furthur changes: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        int driverChoice = int.Parse(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Black;
                        if (driverChoice == 1)
                        {
                            Console.WriteLine("\n\t\t Updating Availability ..!\n");
                            Console.Write("\t\tEnter A/a is you are Avaiable: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            char availChoice = char.Parse(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.Black;
                            if (availChoice == 'A' || availChoice == 'a')
                            {
                                Console.WriteLine("\t\tYou are Available to pick rides!");
                                d.updateAvailibility(true);
                                goto DriverMenu;
                            }
                            else
                            {
                                Console.WriteLine("\t\tYou are not Available to pick rides!");
                                d1.updateAvailibility(false);
                                goto DriverMenu;
                            }

                        }
                        else if (driverChoice == 2)
                        {
                            Console.WriteLine("\t\t Updating Location ..!\n");
                            Console.Write("\t\tEnter new location (Latitude, Longitude): ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            float newLat = float.Parse(Console.ReadLine());
                            float newLon = float.Parse(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.Black;
                            d1.currLocation.setLocation(newLat, newLon);
                            goto DriverMenu;

                        }
                        else if (driverChoice == 3)
                        {
                            Console.WriteLine("\n\t\tExiting as Driver ..!");
                            goto Start;
                        }
                        else
                        {
                            Console.WriteLine("\t\tInvalid Choice!");
                        }
                    }
                }
                else if (entryChoice == 2)
                {
                    Console.WriteLine("\n\t\t\tSIGN UP as New Driver ...!\n");
                    a.addDriver();
                    goto LoginRegister;
                }


            }
            else if (option == 3)
            {

                Console.WriteLine("\n\tENTER AS ADMIN\n");
                Console.WriteLine("\t\t\tEntering as Admin ...!\n");
            AdminStart:
                Console.WriteLine("\t\t1. Add Driver\n\t\t2. Remove Driver\n\t\t3. Update Driver\n\t\t4. Search Driver\n\t\t5. Exit as Admin\n\n");
                Console.Write("\t\tEnter 1 to 5 for differnet Admin operations: ");
                Console.ForegroundColor = ConsoleColor.Green;
                int adminOption = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Black;

                if (adminOption == 1)
                {
                    Console.WriteLine("\n\t\tAdding new Driver ..!\n");
                    a.addDriver();
                    goto AdminStart;
                }
                else if (adminOption == 2)
                {
                    Console.WriteLine("\n\t\tRemoving a Driver ..!\n");
                    Console.Write("\t\tEnter ID to remove a driver: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    int removeID = int.Parse(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.Black;
                    a.removeDriver(removeID);
                    goto AdminStart;
                }
                else if (adminOption == 3)
                {
                    Console.WriteLine("\n\t\tUpdating a Driver ..!\n");
                    Console.Write("\t\tEnter ID to update a driver's detail: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    int updateID = int.Parse(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.Black;
                    a.updateDriver(updateID);
                    goto AdminStart;
                }
                else if (adminOption == 4)
                {
                    Console.WriteLine("\n\t\tSearching a Driver ..!\n");
                    Console.Write("\t\tEnter ID to search a driver's detail: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    int searchID = int.Parse(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.Black;
                    a.searchDriver(searchID);
                    goto AdminStart;
                }
                else if (adminOption == 5)
                {
                    Console.WriteLine("\n\t\tExiting as Admin ..!\n");
                    goto Start;
                }
            }
            else
            {
                Console.WriteLine("Invalid Option!");
            }
        }
    }
}
