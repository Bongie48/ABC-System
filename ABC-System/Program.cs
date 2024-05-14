using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ABC_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creating instantiation of different carrier capabilities
            GoodDriverStrategy _driver= new GoodDriverStrategy();
            TwoPeopleStrategy _two = new TwoPeopleStrategy();
            FivePeopleStrategy _five= new FivePeopleStrategy();
            TwentyPeopleStrategy _twenty= new TwentyPeopleStrategy();
            SixtyFivePeopleStrategy _sixtyFive= new SixtyFivePeopleStrategy();
            //Creating instantiation of different Engines
            SmallEngineStrategy _small = new SmallEngineStrategy();
            MediumEngineStrategy _medium= new MediumEngineStrategy();
            LargeEngineStrategy _large= new LargeEngineStrategy();
            ExtraLargeStrategy _extraLargeStrategy= new ExtraLargeStrategy();
            //Creating instantiation of different tow capabilities
            TowStrategy _tow = new TowStrategy();
            NotTowStrategy _notTow= new NotTowStrategy();
            //Creating instantiation of different types of vehicles
            Vehicle _bike = new motorbike(_driver, _small, _tow);
            Vehicle _light = new lightvehicle(_driver, _small, _tow);
            Vehicle _heavy = new heavyvehicle(_driver, _small, _tow);

            //Declaring variables
            char sound = 'c';
            char wifi = 'c';
            char camera='c';

            //Print a menu
            Console.WriteLine("Choose one choice from each option\n" +
                "A. Carrier capabilities:\n=========================\n" +
                "1) Good and Driver.\n" +
                "2) 2 people max and bag.\n" +
                "5) 5 people max and few luggage.\n" +
                "20) 20 people max.\n" +
                "65) 65 people max.\n\n" +
                "B. Engine\n==========\n" +
                "1) Small engine.\n" +
                "2) Medium engine.\n" +
                "3) Large engine.\n" +
                "4) Extra large engine.\n\n" +
                "C.Towing capabilities\r\n======================\n" +
                "1) can tow.\n" +
                "2) cannot tow.");
            Console.WriteLine();

            //Prompt and get for item that a vehicle must have
            Console.Write("Enter vehicle type : ");
            string vehicle=Console.ReadLine();
            Console.Write("Enter carrier capability (1,2,5,20,65): ");
            int carrier=int.Parse(Console.ReadLine());
            Console.Write("Enter engine option (1,2,3,4): ");
            int engine=int.Parse(Console.ReadLine());
            Console.Write("Enter tow capability (1,2): ");
            int tow=int.Parse(Console.ReadLine());

            //Ask the user if the vehicle will have extra specs added
            Console.Write("Add extra specs to the vehicle (y/n) ? ");
            char extraSpec=char.Parse(Console.ReadLine());

            if (extraSpec == 'y' || extraSpec == 'Y')
            {
                //Prompt and get for optional extra specs for vehicles 
                Console.Write("Add sound (y/n) ? ");
                sound=char.Parse(Console.ReadLine());
                Console.Write("Add wi-fi (y/n) ? ");
                wifi=char.Parse(Console.ReadLine());
                Console.Write("Add camera (y/n) ? ");
                camera=char.Parse(Console.ReadLine());
            }
            Console.WriteLine() ; 
            if (vehicle == "motobike")
            {
                //Assign the motobike object by calling a return method called AssignMotobike
                _bike=AssignMotobike(sound,wifi,camera, carrier, engine, tow, _bike, _driver, _two, _five, _twenty, _sixtyFive, _small, _medium, _large, _extraLargeStrategy, _tow, _notTow);
                Console.WriteLine(_bike.Description());
                Console.WriteLine($"Total Cost:\t{_bike.Cost(vehicle).ToString("C")}");
            }
            else if (vehicle == "light-vehicle")
            {
                //Assign the light vehicle object by calling a return method called AssignMotobike
                _light = AssignLightVehicle(sound, wifi, camera, carrier, engine, tow,_light, _driver, _two, _five, _twenty, _sixtyFive, _small, _medium, _large, _extraLargeStrategy, _tow, _notTow);
                Console.WriteLine(_light.Description());
                Console.WriteLine($"Total Cost:\t{_light.Cost(vehicle).ToString("C")}");
            }
            else if (vehicle == "heavy-vehicle")
            {
                //Assign the heavy vehicle object by calling a return method called AssignMotobike
                _heavy = AssignHeavyVehicle(sound, wifi, camera, carrier, engine, tow,_heavy, _driver, _two, _five, _twenty, _sixtyFive, _small, _medium, _large, _extraLargeStrategy, _tow, _notTow);
                Console.WriteLine(_heavy.Description());
                Console.WriteLine($"Total Cost:\t{_heavy.Cost(vehicle).ToString("C")}");
                
            }
            else
            {
                Console.WriteLine("Invalid, Choose 1,2 or 3.");
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        //return method that return motobike vehicle object
        static Vehicle AssignMotobike(char sound, char wifi, char camera,int _carrier, int _engine, int _towing, Vehicle _bike, GoodDriverStrategy _driver, TwoPeopleStrategy _two, FivePeopleStrategy _five, TwentyPeopleStrategy _twenty, SixtyFivePeopleStrategy _sixtyFive, SmallEngineStrategy _small, MediumEngineStrategy _medium, LargeEngineStrategy _large, ExtraLargeStrategy _extraLargeStrategy, TowStrategy _tow, NotTowStrategy _notTow)
        {
            _bike.Name = "motobike";
            WiFi _wifi = new WiFi(_bike);
            //if statement that assigns an object according to user input
            if (_carrier == 1)
            {
                if (_engine == 1 && _towing == 1)
                {
                    _bike = new motorbike(_driver, _small, _tow);
                }
                else if (_engine == 1 && _towing == 2)
                {
                    _bike = new motorbike(_driver, _small, _notTow);
                }
                else if (_engine == 2 && _towing == 1)
                {
                    _bike = new motorbike(_driver, _medium, _tow);
                }
                else if (_engine == 2 && _towing == 2)
                {
                    _bike = new motorbike(_driver, _medium, _notTow);
                }   
                else if (_engine == 3 && _towing == 1)
                {
                    _bike = new motorbike(_driver, _large, _tow);
                }
                else if (_engine == 3 && _towing == 2)
                {
                    _bike = new motorbike(_driver, _large, _notTow);
                }
                else if (_engine == 4 && _towing == 1)
                {
                    _bike = new motorbike(_driver, _extraLargeStrategy, _tow);
                }
                else if (_engine == 4 && _towing == 2)
                {
                    _bike = new motorbike(_driver, _extraLargeStrategy, _notTow);
                }
                else
                {
                    Console.WriteLine("Invalid, choose an option from the menu");
                    Console.WriteLine();
                }
            }
            else if (_carrier == 2)
            {
                if (_engine == 1 && _towing == 1)
                {
                    _bike = new motorbike(_two, _small, _tow);
                }
                else if (_engine == 1 && _towing == 2)
                {
                    _bike = new motorbike(_two, _small, _notTow);
                }
                else if (_engine == 2 && _towing == 1)
                {
                    _bike = new motorbike(_two, _medium, _tow);
                }
                else if (_engine == 2 && _towing == 2)
                {
                    _bike = new motorbike(_two, _medium, _notTow);
                }
                else if (_engine == 3 && _towing == 1)
                {
                    _bike = new motorbike(_two, _large, _tow);
                }
                else if (_engine == 3 && _towing == 2)
                {
                    _bike = new motorbike(_two, _large, _notTow);
                }
                else if (_engine == 4 && _towing == 1)
                {
                    _bike = new motorbike(_two, _extraLargeStrategy, _tow);
                }
                else if (_engine == 4 && _towing == 2)
                {
                    _bike = new motorbike(_two, _extraLargeStrategy, _notTow);
                }
                else
                {
                    Console.WriteLine("Invalid, choose an option from the menu");
                    Console.WriteLine();
                }
            }
            else if (_carrier == 5)
            {
                if (_engine == 1 && _towing == 1)
                {
                    _bike = new motorbike(_five, _small, _tow);
                }
                else if (_engine == 1 && _towing == 2)
                {
                    _bike = new motorbike(_five, _small, _notTow);
                }
                else if (_engine == 2 && _towing == 1)
                {
                    _bike = new motorbike(_five, _medium, _tow);
                }
                else if (_engine == 2 && _towing == 2)
                {
                    _bike = new motorbike(_five, _medium, _notTow);
                }
                else if (_engine == 3 && _towing == 1)
                {
                    _bike = new motorbike(_five, _large, _tow);
                }
                else if (_engine == 3 && _towing == 2)
                {
                    _bike = new motorbike(_five, _large, _notTow);
                }
                else if (_engine == 4 && _towing == 1)
                {
                    _bike = new motorbike(_five, _extraLargeStrategy, _tow);
                }
                else if (_engine == 4 && _towing == 2)
                {
                    _bike = new motorbike(_five, _extraLargeStrategy, _notTow);
                }
                else
                {
                    Console.WriteLine("Invalid, choose an option from the menu");
                    Console.WriteLine();
                }
            }
            else if (_carrier == 20)
            {
                if (_engine == 1 && _towing == 1)
                {
                    _bike = new motorbike(_twenty, _small, _tow);
                }
                else if (_engine == 1 && _towing == 2)
                {
                    _bike = new motorbike(_twenty, _small, _notTow);
                }
                else if (_engine == 2 && _towing == 1)
                {
                    _bike = new motorbike(_twenty, _medium, _tow);
                }
                else if (_engine == 2 && _towing == 2)
                {
                    _bike = new motorbike(_twenty, _medium, _notTow);
                }
                else if (_engine == 3 && _towing == 1)
                {
                    _bike = new motorbike(_twenty, _large, _tow);
                }
                else if (_engine == 3 && _towing == 2)
                {
                    _bike = new motorbike(_twenty, _large, _notTow);
                }
                else if (_engine == 4 && _towing == 1)
                {
                    _bike = new motorbike(_twenty, _extraLargeStrategy, _tow);
                }
                else if (_engine == 4 && _towing == 2)
                {
                    _bike = new motorbike(_twenty, _extraLargeStrategy, _notTow);
                }
                else
                {
                    Console.WriteLine("Invalid, choose an option from the menu");
                    Console.WriteLine();
                }
            }
            else if (_carrier == 65)
            {
                if (_engine == 1 && _towing == 1)
                {
                    _bike = new motorbike(_sixtyFive, _small, _tow);
                }
                else if (_engine == 1 && _towing == 2)
                {
                    _bike = new motorbike(_sixtyFive, _small, _notTow);
                }
                else if (_engine == 2 && _towing == 1)
                {
                    _bike = new motorbike(_sixtyFive, _medium, _tow);
                }
                else if (_engine == 2 && _towing == 2)
                {
                    _bike = new motorbike(_sixtyFive, _medium, _notTow);
                }
                else if (_engine == 3 && _towing == 1)
                {
                    _bike = new motorbike(_sixtyFive, _large, _tow);
                }
                else if (_engine == 3 && _towing == 2)
                {
                    _bike = new motorbike(_sixtyFive, _large, _notTow);
                }
                else if (_engine == 4 && _towing == 1)
                {
                    _bike = new motorbike(_sixtyFive, _extraLargeStrategy, _tow);
                }
                else if (_engine == 4 && _towing == 2)
                {
                    _bike = new motorbike(_sixtyFive, _extraLargeStrategy, _notTow);
                }
                else
                {
                    Console.WriteLine("Invalid, choose an option from the menu");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Invalid, choose an option from the menu");
                Console.WriteLine();
            }
            if (sound == 'Y' || sound == 'y')
            {
                _bike = new Sound(_bike);
            }
            if (wifi == 'Y' || wifi == 'y')
            {
                technician(1, _wifi,sound);
                _bike = new WiFi(_bike);
            }
            if (camera == 'Y' || camera == 'y')
            {
                _bike = new Camera(_bike);
            }
            
            return _bike;
            
        }
        //return method that return light vehicle vehicle object
        static Vehicle AssignLightVehicle(char sound, char wifi, char camera, int _carrier, int _engine, int _towing, Vehicle _light, GoodDriverStrategy _driver, TwoPeopleStrategy _two, FivePeopleStrategy _five, TwentyPeopleStrategy _twenty, SixtyFivePeopleStrategy _sixtyFive, SmallEngineStrategy _small, MediumEngineStrategy _medium, LargeEngineStrategy _large, ExtraLargeStrategy _extraLargeStrategy, TowStrategy _tow, NotTowStrategy _notTow)
        {
            _light.Name = "light-vehicle";
            WiFi _wifi = new WiFi(_light);
            //if statement that assigns an object according to user input
            if (_carrier == 1)
            {
                if (_engine == 1 && _towing == 1)
                {
                    _light = new lightvehicle(_driver, _small, _tow);
                }
                else if (_engine == 1 && _towing == 2)
                {
                    _light = new lightvehicle(_driver, _small, _notTow);
                }
                else if (_engine == 2 && _towing == 1)
                {
                    _light = new lightvehicle(_driver, _medium, _tow);
                }
                else if (_engine == 2 && _towing == 2)
                {
                    _light = new lightvehicle(_driver, _medium, _notTow);
                }
                else if (_engine == 3 && _towing == 1)
                {
                    _light = new lightvehicle(_driver, _large, _tow);
                }
                else if (_engine == 3 && _towing == 2)
                {
                    _light = new lightvehicle(_driver, _large, _notTow);
                }
                else if (_engine == 4 && _towing == 1)
                {
                    _light = new lightvehicle(_driver, _extraLargeStrategy, _tow);
                }
                else if (_engine == 4 && _towing == 2)
                {
                    _light = new lightvehicle(_driver, _extraLargeStrategy, _notTow);
                }
                else
                {
                    Console.WriteLine("Invalid, choose an option from the menu");
                    Console.WriteLine();
                }
            }
            else if (_carrier == 2)
            {
                if (_engine == 1 && _towing == 1)
                {
                    _light = new lightvehicle(_two, _small, _tow);
                }
                else if (_engine == 1 && _towing == 2)
                {
                    _light = new lightvehicle(_two, _small, _notTow);
                }
                else if (_engine == 2 && _towing == 1)
                {
                    _light = new lightvehicle(_two, _medium, _tow);
                }
                else if (_engine == 2 && _towing == 2)
                {
                    _light = new lightvehicle(_two, _medium, _notTow);
                }
                else if (_engine == 3 && _towing == 1)
                {
                    _light = new lightvehicle(_two, _large, _tow);
                }
                else if (_engine == 3 && _towing == 2)
                {
                    _light = new lightvehicle(_two, _large, _notTow);
                }
                else if (_engine == 4 && _towing == 1)
                {
                    _light = new lightvehicle(_two, _extraLargeStrategy, _tow);
                }
                else if (_engine == 4 && _towing == 2)
                {
                    _light = new lightvehicle(_two, _extraLargeStrategy, _notTow);
                }
                else
                {
                    Console.WriteLine("Invalid, choose an option from the menu");
                    Console.WriteLine();
                }
            }
            else if (_carrier == 5)
            {
                if (_engine == 1 && _towing == 1)
                {
                    _light = new lightvehicle(_five, _small, _tow);
                }
                else if (_engine == 1 && _towing == 2)
                {
                    _light = new lightvehicle(_five, _small, _notTow);
                }
                else if (_engine == 2 && _towing == 1)
                {
                    _light = new lightvehicle(_five, _medium, _tow);
                }
                else if (_engine == 2 && _towing == 2)
                {
                    _light = new lightvehicle(_five, _medium, _notTow);
                }
                else if (_engine == 3 && _towing == 1)
                {
                    _light = new lightvehicle(_five, _large, _tow);
                }
                else if (_engine == 3 && _towing == 2)
                {
                    _light = new lightvehicle(_five, _large, _notTow);
                }
                else if (_engine == 4 && _towing == 1)
                {
                    _light = new lightvehicle(_five, _extraLargeStrategy, _tow);
                }
                else if (_engine == 4 && _towing == 2)
                {
                    _light = new lightvehicle(_five, _extraLargeStrategy, _notTow);
                }
                else
                {
                    Console.WriteLine("Invalid, choose an option from the menu");
                    Console.WriteLine();
                }
            }
            else if (_carrier == 20)
            {
                if (_engine == 1 && _towing == 1)
                {
                    _light = new lightvehicle(_twenty, _small, _tow);
                }
                else if (_engine == 1 && _towing == 2)
                {
                    _light = new lightvehicle(_twenty, _small, _notTow);
                }
                else if (_engine == 2 && _towing == 1)
                {
                    _light = new lightvehicle(_twenty, _medium, _tow);
                }
                else if (_engine == 2 && _towing == 2)
                {
                    _light = new lightvehicle(_twenty, _medium, _notTow);
                }
                else if (_engine == 3 && _towing == 1)
                {
                    _light = new lightvehicle(_twenty, _large, _tow);
                }
                else if (_engine == 3 && _towing == 2)
                {
                    _light = new lightvehicle(_twenty, _large, _notTow);
                }
                else if (_engine == 4 && _towing == 1)
                {
                    _light = new lightvehicle(_twenty, _extraLargeStrategy, _tow);
                }
                else if (_engine == 4 && _towing == 2)
                {
                    _light = new lightvehicle(_twenty, _extraLargeStrategy, _notTow);
                }
                else
                {
                    Console.WriteLine("Invalid, choose an option from the menu");
                    Console.WriteLine();
                }
            }
            else if (_carrier == 65)
            {
                if (_engine == 1 && _towing == 1)
                {
                    _light = new lightvehicle(_sixtyFive, _small, _tow);
                }
                else if (_engine == 1 && _towing == 2)
                {
                    _light = new lightvehicle(_sixtyFive, _small, _notTow);
                }
                else if (_engine == 2 && _towing == 1)
                {
                    _light = new lightvehicle(_sixtyFive, _medium, _tow);
                }
                else if (_engine == 2 && _towing == 2)
                {
                    _light = new lightvehicle(  _sixtyFive, _medium, _notTow);
                }
                else if (_engine == 3 && _towing == 1)
                {
                    _light = new lightvehicle(_sixtyFive, _large, _tow);
                }
                else if (_engine == 3 && _towing == 2)
                {   
                    _light = new lightvehicle(_sixtyFive, _large, _notTow);
                }
                else if (_engine == 4 && _towing == 1)
                {
                    _light = new lightvehicle(_sixtyFive, _extraLargeStrategy, _tow);
                }
                else if (_engine == 4 && _towing == 2)
                {
                    _light = new lightvehicle(_sixtyFive, _extraLargeStrategy, _notTow);
                }
                else
                {
                    Console.WriteLine("Invalid, choose an option from the menu");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Invalid, choose an option from the menu");
                Console.WriteLine();
            }
            if (sound == 'Y' || sound == 'y')
            {
                _light = new Sound(_light);
            }
            if (wifi == 'Y' || wifi == 'y')
            {
                technician(2, _wifi, sound);
                _light = new WiFi(_light);
            }
            if (camera == 'Y' || camera == 'y')
            {
                _light = new Camera(_light);
            }
            return _light;
        }
        //return method that return light vehicle vehicle object
        static Vehicle AssignHeavyVehicle(char sound, char wifi, char camera, int _carrier, int _engine, int _towing, Vehicle _heavy, GoodDriverStrategy _driver, TwoPeopleStrategy _two, FivePeopleStrategy _five, TwentyPeopleStrategy _twenty, SixtyFivePeopleStrategy _sixtyFive, SmallEngineStrategy _small, MediumEngineStrategy _medium, LargeEngineStrategy _large, ExtraLargeStrategy _extraLargeStrategy, TowStrategy _tow, NotTowStrategy _notTow)
        {
            _heavy.Name = "heavy-vehicle";
            WiFi _wifi= new WiFi(_heavy);
            //if statement that assigns an object according to user input
            if (_carrier == 1)
            {
                if (_engine == 1 && _towing == 1)
                {
                    _heavy = new heavyvehicle(_driver, _small, _tow);
                }
                else if (_engine == 1 && _towing == 2)
                {
                    _heavy = new heavyvehicle(_driver, _small, _notTow);
                }
                else if (_engine == 2 && _towing == 1)
                {
                    _heavy = new heavyvehicle(_driver, _medium, _tow);
                }
                else if (_engine == 2 && _towing == 2)
                {
                    _heavy = new heavyvehicle(_driver, _medium, _notTow);
                }
                else if (_engine == 3 && _towing == 1)
                {
                    _heavy = new heavyvehicle(_driver, _large, _tow);
                }
                else if (_engine == 3 && _towing == 2)
                {
                    _heavy = new heavyvehicle(_driver, _large, _notTow);
                }
                else if (_engine == 4 && _towing == 1)
                {
                    _heavy = new heavyvehicle(_driver, _extraLargeStrategy, _tow);
                }
                else if (_engine == 4 && _towing == 2)
                {
                    _heavy = new heavyvehicle(_driver, _extraLargeStrategy, _notTow);
                }
                else
                {
                    Console.WriteLine("Invalid, choose an option from the menu");
                    Console.WriteLine();
                }
            }
            else if (_carrier == 2)
            {
                if (_engine == 1 && _towing == 1)
                {
                    _heavy = new heavyvehicle(_two, _small, _tow);
                }
                else if (_engine == 1 && _towing == 2)
                {
                    _heavy = new heavyvehicle(_two, _small, _notTow);
                }
                else if (_engine == 2 && _towing == 1)
                {
                    _heavy = new heavyvehicle(_two, _medium, _tow);
                }
                else if (_engine == 2 && _towing == 2)
                {
                    _heavy = new heavyvehicle(_two, _medium, _notTow);
                }
                else if (_engine == 3 && _towing == 1)
                {
                    _heavy = new heavyvehicle(_two, _large, _tow);
                }
                else if (_engine == 3 && _towing == 2)
                {
                    _heavy = new heavyvehicle(_two, _large, _notTow);
                }
                else if (_engine == 4 && _towing == 1)
                {
                    _heavy = new heavyvehicle(_two, _extraLargeStrategy, _tow);
                }
                else if (_engine == 4 && _towing == 2)
                {
                    _heavy = new heavyvehicle(_two, _extraLargeStrategy, _notTow);
                }
                else
                {
                    Console.WriteLine("Invalid, choose an option from the menu");
                    Console.WriteLine();
                }
            }
            else if (_carrier == 5)
            {
                if (_engine == 1 && _towing == 1)
                {
                    _heavy = new heavyvehicle(_five, _small, _tow);
                }
                else if (_engine == 1 && _towing == 2)
                {
                    _heavy = new heavyvehicle(_five, _small, _notTow);
                }   
                else if (_engine == 2 && _towing == 1)
                {
                    _heavy = new heavyvehicle(_five, _medium, _tow);
                }
                else if (_engine == 2 && _towing == 2)
                {
                    _heavy = new heavyvehicle(_five, _medium, _notTow);
                }
                else if (_engine == 3 && _towing == 1)
                {
                    _heavy = new heavyvehicle(_five, _large, _tow);
                }
                else if (_engine == 3 && _towing == 2)
                {
                    _heavy = new heavyvehicle(_five, _large, _notTow);
                }
                else if (_engine == 4 && _towing == 1)
                {
                    _heavy = new heavyvehicle(_five, _extraLargeStrategy, _tow);
                }
                else if (_engine == 4 && _towing == 2)
                {
                    _heavy = new heavyvehicle(_five, _extraLargeStrategy, _notTow);
                }
                else
                {
                    Console.WriteLine("Invalid, choose an option from the menu");
                    Console.WriteLine();
                }
            }
            else if (_carrier == 20)
            {
                if (_engine == 1 && _towing == 1)
                {
                    _heavy = new heavyvehicle(_twenty, _small, _tow);
                }
                else if (_engine == 1 && _towing == 2)
                {
                    _heavy = new heavyvehicle(_twenty, _small, _notTow);
                }
                else if (_engine == 2 && _towing == 1)
                {   
                    _heavy = new heavyvehicle(_twenty, _medium, _tow);
                }
                else if (_engine == 2 && _towing == 2)
                {
                    _heavy = new heavyvehicle(_twenty, _medium, _notTow);
                }
                else if (_engine == 3 && _towing == 1)
                {
                    _heavy = new heavyvehicle(_twenty, _large, _tow);
                }
                else if (_engine == 3 && _towing == 2)
                {
                    _heavy = new heavyvehicle(_twenty, _large, _notTow);
                }
                else if (_engine == 4 && _towing == 1)
                {
                    _heavy = new heavyvehicle(_twenty, _extraLargeStrategy, _tow);
                }
                else if (_engine == 4 && _towing == 2)
                {
                    _heavy = new heavyvehicle(_twenty, _extraLargeStrategy, _notTow);
                }
                else
                {
                    Console.WriteLine("Invalid, choose an option from the menu");
                    Console.WriteLine();
                }
            }
            else if (_carrier == 65)
            {
                if (_engine == 1 && _towing == 1)
                {
                    _heavy = new heavyvehicle(_sixtyFive, _small, _tow);
                }
                else if (_engine == 1 && _towing == 2)
                {
                    _heavy = new heavyvehicle(_sixtyFive, _small, _notTow);
                }
                else if (_engine == 2 && _towing == 1)
                {
                    _heavy = new heavyvehicle(_sixtyFive, _medium, _tow);
                }
                else if (_engine == 2 && _towing == 2)
                {
                    _heavy = new heavyvehicle( _sixtyFive, _medium, _notTow);
                }
                else if (_engine == 3 && _towing == 1)
                {
                    _heavy = new heavyvehicle(_sixtyFive, _large, _tow);
                }
                else if (_engine == 3 && _towing == 2)
                {
                    _heavy = new heavyvehicle(_sixtyFive, _large, _notTow);
                }
                else if (_engine == 4 && _towing == 1)
                {
                    _heavy = new heavyvehicle(_sixtyFive, _extraLargeStrategy, _tow);
                }
                else if (_engine == 4 && _towing == 2)
                {
                    _heavy = new heavyvehicle(_sixtyFive, _extraLargeStrategy, _notTow);
                }
                else
                {
                    Console.WriteLine("Invalid, choose an option from the menu");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Invalid, choose an option from the menu");
                Console.WriteLine();
            }
            if (sound == 'Y' || sound == 'y')
            {
                _heavy = new Sound(_heavy);
            }
            if (wifi == 'Y' || wifi == 'y')
            {
                technician(3, _wifi,sound);
                _heavy = new WiFi(_heavy);
            }
            if (camera == 'Y' || camera == 'y')
            {
                _heavy = new Camera(_heavy);
            }
            return _heavy;
        }
        static void technician(int type, WiFi _wifi,char sound)
        {
           
            Console.Write("How many technicians do you want to update: ");
            int TechnicianNumber=int.Parse(Console.ReadLine());
            string[] motoTech = new string[TechnicianNumber]; //Array that holds different technicians name for moto bike vehicle
            string[] HeavyLightTech = new string[TechnicianNumber]; //Array that holds different technicians name for heavy and light vehicle
            for (int x = 0; x < TechnicianNumber; x = x + 1)
            {
                
                if (type == 1)
                {
                    //Prompt and get for motobike technician name
                    Console.Write("Enter Technician name: ");
                    motoTech[x] = Console.ReadLine();
                }
                else if (type == 2 || type == 3)
                {
                    //Prompt and get for light and heavy vehicle technician name
                    Console.Write("Enter Technician name: ");
                    HeavyLightTech[x] = Console.ReadLine();
                }
            }
            if (type == 1)
            {
                for(int x = 0; x < motoTech.Length; x = x+1)
                {
                    motobikeTech _motoTech = new motobikeTech(motoTech[x]);
                    //Adding a new subscriber to be updated if there a wifi on a moto bike
                    _wifi.AddTechnician(_motoTech, type);
                }
               
                Console.WriteLine();
            }
            else if (type == 2 || type == 3)
            {
                for (int x = 0; x < HeavyLightTech.Length; x = x + 1)
                {
                    HeavyLightTech _heavylightTech = new HeavyLightTech(HeavyLightTech[x]);
                    //Adding a new subscriber to be updated if there a wifi on a light and heavy vehicle
                    _wifi.AddTechnician(_heavylightTech, type);
                }
                Console.WriteLine();
            }
            //if statement to determine which message should sent to the subscribers
            if (sound == 'y' || sound == 'Y')
            {
                _wifi.GetState($"has wifi installed diagnostics can be performed or daily news can be provided, and the sound system can be updated.");
                Console.WriteLine();
            }
            else
            {
                _wifi.GetState($"has wifi installed diagnostics can be performed or daily news can be provided.");
                Console.WriteLine();
            }
        }
    }
    
    //Carrier capabilities strategy pattern
    public interface ICarrierCapability //Strategy base 
    {
        string DefineCapability();
    }
    public class GoodDriverStrategy : ICarrierCapability //Concrete strategy 
    {
        public string DefineCapability()
        {
            return "Good and Driver.";
        }
    }
    public class TwoPeopleStrategy : ICarrierCapability //Concrete strategy
    {
        public string DefineCapability()
        {
            return "2 people max and bag.";
        }
    }
    public class FivePeopleStrategy : ICarrierCapability //Concrete strategy
    {
        public string DefineCapability()
        {
            return "5 people max and few luggage.";
        }
    }
    public class TwentyPeopleStrategy : ICarrierCapability //Concrete strategy
    {
        public string DefineCapability()
        {
            return "20 people max.";
        }
    }
    public class SixtyFivePeopleStrategy : ICarrierCapability //Concrete strategy
    {
        public string DefineCapability()
        {
            return "65 people max.";
        }
    }
    //Engine strategy pattern
    public interface IEngineStrategy //Strategy base
    {
        string DefineEngine();
    }
    public class SmallEngineStrategy : IEngineStrategy //Concrete strategy
    {
        public string DefineEngine()
        {
            return "Small engine.";
        }
    }
    public class MediumEngineStrategy : IEngineStrategy //Concrete strategy
    {
        public  string DefineEngine()
        {
            return "Medium engine.";
        }
    }
    public class LargeEngineStrategy : IEngineStrategy //Concrete strategy
    {
        public string DefineEngine()
        {
            return "Large engine.";
        }
    }
    public class ExtraLargeStrategy : IEngineStrategy //Concrete strategy
    {
        public string DefineEngine()
        {
            return "Extra large engine.";
        }
    }
    //Towing capabilities strategy pattern
    public interface ITowingCapability //Strategy base
    {
        string DefineTowingCapability();
    }
    public class TowStrategy : ITowingCapability //Concrete strategy
    {
        public string DefineTowingCapability()
        {
            return "can tow.";
        }
    }
    public class NotTowStrategy : ITowingCapability //Concrete strategy
    {
        public string DefineTowingCapability()
        {
            return "cannot tow.";
        }
    }
    
    //Vehicle Decorator pattern for adding extra specs
    public abstract class Vehicle //Component base
    {
        public string Name { get; set; }
        public abstract string Description();
        public abstract double Cost(string vehicleType);
    }
    public class motorbike : Vehicle //Concrete component and a client class for ICarrierCapability, IEngine, ITowingCapability strategy
    {
        public ICarrierCapability _carrier { get; set; }
        public IEngineStrategy _engine { get; set; }
        public ITowingCapability _tow { get; set; }
        public motorbike(ICarrierCapability carrier, IEngineStrategy engine, ITowingCapability tow)
        {
            this._carrier = carrier;
            this._engine = engine;
            this._tow = tow;
            this.Name = "motobike";
        }
        public override string Description()
        {
            string GetCarrier = _carrier.DefineCapability();
            string GetEngine = _engine.DefineEngine();
            string GetTow = _tow.DefineTowingCapability();
            return $"The motobike has the following specs:\n{GetCarrier}\n{GetEngine}\n{GetTow}";   
        }
        public override double Cost(string vehicleType)
        {
            return 50000.00;
        }
    }
    public class lightvehicle : Vehicle //Concrete component and a client class for ICarrierCapability, IEngine, ITowingCapability strategy
    {
        public ICarrierCapability _carrier { get; set; }
        public IEngineStrategy _engine { get; set; }
        public ITowingCapability _tow { get; set; }
        public lightvehicle(ICarrierCapability carrier, IEngineStrategy engine, ITowingCapability tow)
        {
            this._carrier = carrier;
            this._engine = engine;
            this._tow = tow;
            this.Name="light-vehicle";
        }
        public override string Description()
        {
            string GetCarrier = _carrier.DefineCapability();
            string GetEngine = _engine.DefineEngine();
            string GetTow = _tow.DefineTowingCapability();
            return $"The light vehicle has the following specs:\n{GetCarrier}\n{GetEngine}\n{GetTow}";
        }
        public override double Cost(string vehicleType)
        {
            return 95000.00;
        }
    }
    public class heavyvehicle : Vehicle //Concrete component and a client class for ICarrierCapability, IEngine, ITowingCapability strategy
    {
        public ICarrierCapability _carrier { get; set; }
        public IEngineStrategy _engine { get; set; }
        public ITowingCapability _tow { get; set; }
        public heavyvehicle(ICarrierCapability carrier, IEngineStrategy engine, ITowingCapability tow)
        {
            this._carrier = carrier;
            this._engine = engine;
            this._tow = tow;
            this.Name="heavy-vehicle";
        }
        public override string Description()
        {
            string GetCarrier = _carrier.DefineCapability();
            string GetEngine = _engine.DefineEngine();
            string GetTow = _tow.DefineTowingCapability();
            return $"The heavy vehicle has the following specs:\n{GetCarrier}\n{GetEngine}\n{GetTow}";
            
        }
        public override double Cost(string vehicleType)
        {
            return 500000.00;
        }
    }
    public abstract class VehicleDecorator : Vehicle //Decorator base
    {
        Vehicle _vehicle;
        public VehicleDecorator(Vehicle vehicle)
        {
            _vehicle = vehicle;
        }
        public override string Description()
        {
            return _vehicle.Description();
        }
        public override double Cost(string vehicleType)
        {
            return _vehicle.Cost(vehicleType);
        }
    }
    public class Sound : VehicleDecorator //Concrete decorator, adds sound
    {
        Vehicle _vehicle;
        
        public Sound(Vehicle vehicle):base(vehicle)
        {
            _vehicle = vehicle;
        }
        public override string Description()
        {
             return _vehicle.Description()+ AddSound();
        }
        public string AddSound()
        {
            return "\nSound system added";
        }
        public override double Cost(string vehicleType)
        {
            double totalCost=0;
            if (vehicleType == "motobike") 
            {
                totalCost= _vehicle.Cost(vehicleType) + 200.00;
            }
            else if(vehicleType == "light-vehicle")
            {
                totalCost = _vehicle.Cost(vehicleType) + 150.00;
            }
            else if(vehicleType == "heavy-vehicle")
            {
                totalCost = _vehicle.Cost(vehicleType) + 300.00;
            }
            return totalCost;
        }
    }
    public class Camera : VehicleDecorator //Concrete decorator, adds camera
    {
        Vehicle _vehicle;
        public Camera(Vehicle vehicle) : base(vehicle)
        {
            _vehicle = vehicle;
        }
        public override string Description()
        {
            return _vehicle.Description() + AddCamera();
        }
        public string AddCamera()
        {
            return "\nCamera added";
        }
        public override double Cost(string vehicleType)
        {
            double totalCost = 0;
            if (vehicleType == "motobike")
            {
                totalCost = _vehicle.Cost(vehicleType) + 750.00; ;
            }
            else if (vehicleType == "light-vehicle")
            {
                totalCost = _vehicle.Cost(vehicleType) + 400.00;
            }
            else if (vehicleType == "heavy-vehicle")
            {
                totalCost = _vehicle.Cost(vehicleType) + 900.00;
            }
            return totalCost;
        }
    }
    public interface IObserver //Observer base
    {
        void Update(string message);
    }
    public interface IWifi //Subject base
    {
        void AddTechnician(IObserver technician, int name);
        void RemoveTechnician(IObserver technician);
        void Notify(string message, string name);
    }
    public class WiFi : VehicleDecorator, IWifi //Concrete decorator, adds wifi and is a concrete subject of IWifi 
    {
        Vehicle _vehicle;
        private string NewMessage;
        public string newMessage;
        private List<IObserver> _motolist = new List<IObserver>();
        private List<IObserver> _heavyLightList = new List<IObserver>();
        public WiFi(Vehicle vehicle):base(vehicle) 
        {
            _vehicle = vehicle;
            
        }
        public override string Description()
        {
            return _vehicle.Description()+ AddWiFi();
        }
        public string AddWiFi()
        {
            return "\nWiFi added";
        }
        public override double Cost(string vehicleType)
        {
            double totalCost = 0;
            if (vehicleType == "motobike")
            {
                totalCost = _vehicle.Cost(vehicleType) + 300.00;
            }
            else if (vehicleType == "light-vehicle")
            {
                totalCost = _vehicle.Cost(vehicleType) + 450.00;
            }
            else if (vehicleType =="heavy-vehicle")
            {
                totalCost = _vehicle.Cost(vehicleType) + 450;
            }
            return totalCost;
        }
        public void AddTechnician(IObserver technician, int name)
        {
            if (name == 1)
            {
                _motolist.Add(technician);
            }
            else if (name == 2 || name == 3)
            {
                _heavyLightList.Add(technician);
            }
        }
        public void RemoveTechnician(IObserver technician)
        {
            _motolist.Remove(technician);
        }
        public void Notify(string message,string name)
        {
            if (name == "motobike")
            {
                foreach (IObserver _tech in _motolist)
                {
                    _tech.Update(message);
                }
            }
            else if (name == "light-vehicle" || name == "heavy-vehicle")
            {
                foreach (IObserver _tech in _heavyLightList)
                {
                    _tech.Update(message);
                }
            }
        }
        public void GetState(string message)//Concrete subject
        {
            NewMessage = "The "+_vehicle.Name+" "+message;
            Notify(NewMessage, _vehicle.Name);
        }
    }
    public class motobikeTech:IObserver //Concrete observer of IObserver
    {
        private string Name;
        public motobikeTech(string name)
        {
            Name = name;
        }
        public void Update(string newMessage)
        {
            Console.WriteLine($"{Name} received the following message: \n{newMessage}");
            Console.WriteLine();
        }    
    }
    public class HeavyLightTech : IObserver //Concrete observer of IObserver
    {
        private string Name;
        public HeavyLightTech(string name)
        {
            Name = name;
        }
        public void Update(string newMessage)
        {
            Console.WriteLine($"{Name} received the following message: \n{newMessage}");
            Console.WriteLine();
        }
        
    }
}
