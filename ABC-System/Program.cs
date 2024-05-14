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
            GoodDriverStrategy _driver= new GoodDriverStrategy();
            TwoPeopleStrategy _two = new TwoPeopleStrategy();
            FivePeopleStrategy _five= new FivePeopleStrategy();
            TwentyPeopleStrategy _twenty= new TwentyPeopleStrategy();
            SixtyFivePeopleStrategy _sixtyFive= new SixtyFivePeopleStrategy();
            SmallEngineStrategy _small= new SmallEngineStrategy();
            MediumEngineStrategy _medium= new MediumEngineStrategy();
            LargeEngineStrategy _large= new LargeEngineStrategy();
            ExtraLargeStrategy _extraLargeStrategy= new ExtraLargeStrategy();
            TowStrategy _tow= new TowStrategy();
            NotTowStrategy _notTow= new NotTowStrategy();
            Vehicle _bike = new motorbike(_driver, _small, _tow);
            Vehicle _light = new lightvehicle(_driver, _small, _tow);
            Vehicle _heavy = new heavyvehicle(_driver, _small, _tow);
            char sound = 'c';
            char wifi = 'c';
            char camera='c';
            Console.WriteLine("Choose one choice from each option\nA. Carrier capabilities:\n=========================\n1) Good and Driver.\n2) 2 people max and bag.\n5) 5 people max and few luggage.\n20) 20 people max.\n65) 65 people max.\n\nB. Engine\n==========\n1) Small engine.\n2) Medium engine.\n3) Large engine.\n4) Extra large engine.\n\nC.Towing capabilities\r\n======================\n1) can tow.\n2) cannot tow.");
            Console.WriteLine();
            Console.Write("Enter vehicle type (1/2/3): ");
            int vehicle=int.Parse(Console.ReadLine());
            Console.Write("Enter carrier capability (1,2,5,20,65): ");
            int y=int.Parse(Console.ReadLine());
            Console.Write("Enter engine option (1,2,3,4): ");
            int x=int.Parse(Console.ReadLine());
            Console.Write("Enter tow capability (1,2): ");
            int z=int.Parse(Console.ReadLine());
            Console.Write("Add extra specs to the vehicle (y/n) ? ");
            char extraSpec=char.Parse(Console.ReadLine());
            if (extraSpec == 'y' || extraSpec == 'Y')
            {
                Console.Write("Add sound (y/n) ? ");
                sound=char.Parse(Console.ReadLine());
                Console.Write("Add wi-fi (y/n) ? ");
                wifi=char.Parse(Console.ReadLine());
                Console.Write("Add camera (y/n) ? ");
                camera=char.Parse(Console.ReadLine());
            }
            Console.WriteLine() ; 
            if (vehicle == 1)
            {
                _bike=AssignMotobike(sound,wifi,camera,y, x, z, _bike, _driver, _two, _five, _twenty, _sixtyFive, _small, _medium, _large, _extraLargeStrategy, _tow, _notTow);
                Console.WriteLine(_bike.Description());
                Console.WriteLine($"Total Cost:\t{_bike.Cost(vehicle).ToString("C")}");
            }
            else if (vehicle == 2)
            {
                _light=AssignLightVehicle(sound, wifi, camera, y, x, z,_light, _driver, _two, _five, _twenty, _sixtyFive, _small, _medium, _large, _extraLargeStrategy, _tow, _notTow);
                Console.WriteLine(_light.Description());
                Console.WriteLine($"Total Cost:\t{_light.Cost(vehicle).ToString("C")}");
            }
            else if (vehicle == 3)
            {
                _heavy=AssignHeavyVehicle(sound, wifi, camera, y, x, z,_heavy, _driver, _two, _five, _twenty, _sixtyFive, _small, _medium, _large, _extraLargeStrategy, _tow, _notTow);
                Console.WriteLine(_heavy.Description());
                Console.WriteLine($"Total Cost:\t{_bike.Cost(vehicle).ToString("C")}");
                
            }
            else
            {
                Console.WriteLine("Invalid, Choose 1,2 or 3.");
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        static Vehicle AssignMotobike(char sound, char wifi, char camera,int y,int x,int z,Vehicle _bike, GoodDriverStrategy _driver, TwoPeopleStrategy _two, FivePeopleStrategy _five, TwentyPeopleStrategy _twenty, SixtyFivePeopleStrategy _sixtyFive, SmallEngineStrategy _small, MediumEngineStrategy _medium, LargeEngineStrategy _large, ExtraLargeStrategy _extraLargeStrategy, TowStrategy _tow, NotTowStrategy _notTow)
        {
            _bike.Name = "motobike";
            WiFi _wifi = new WiFi(_bike);
            if (y == 1)
            {
                if (x == 1 && z == 1)
                {
                    _bike = new motorbike(_driver, _small, _tow);
                }
                else if (x == 1 && z == 2)
                {
                    _bike = new motorbike(_driver, _small, _notTow);
                }
                else if (x == 2 && z == 1)
                {
                    _bike = new motorbike(_driver, _medium, _tow);
                }
                else if (x == 2 && z == 2)
                {
                    _bike = new motorbike(_driver, _medium, _notTow);
                }   
                else if (x == 3 && z == 1)
                {
                    _bike = new motorbike(_driver, _large, _tow);
                }
                else if (x == 3 && z == 2)
                {
                    _bike = new motorbike(_driver, _large, _notTow);
                }
                else if (x == 4 && z == 1)
                {
                    _bike = new motorbike(_driver, _extraLargeStrategy, _tow);
                }
                else if (x == 4 && z == 2)
                {
                    _bike = new motorbike(_driver, _extraLargeStrategy, _notTow);
                }
                else
                {
                    Console.WriteLine("Invalid, choose an option from the menu");
                    Console.WriteLine();
                }
            }
            else if (y == 2)
            {
                if (x == 1 && z == 1)
                {
                    _bike = new motorbike(_two, _small, _tow);
                }
                else if (x == 1 && z == 2)
                {
                    _bike = new motorbike(_two, _small, _notTow);
                }
                else if (x == 2 && z == 1)
                {
                    _bike = new motorbike(_two, _medium, _tow);
                }
                else if (x == 2 && z == 2)
                {
                    _bike = new motorbike(_two, _medium, _notTow);
                }
                else if (x == 3 && z == 1)
                {
                    _bike = new motorbike(_two, _large, _tow);
                }
                else if (x == 3 && z == 2)
                {
                    _bike = new motorbike(_two, _large, _notTow);
                }
                else if (x == 4 && z == 1)
                {
                    _bike = new motorbike(_two, _extraLargeStrategy, _tow);
                }
                else if (x == 4 && z == 2)
                {
                    _bike = new motorbike(_two, _extraLargeStrategy, _notTow);
                }
                else
                {
                    Console.WriteLine("Invalid, choose an option from the menu");
                    Console.WriteLine();
                }
            }
            else if (y == 5)
            {
                if (x == 1 && z == 1)
                {
                    _bike = new motorbike(_five, _small, _tow);
                }
                else if (x == 1 && z == 2)
                {
                    _bike = new motorbike(_five, _small, _notTow);
                }
                else if (x == 2 && z == 1)
                {
                    _bike = new motorbike(_five, _medium, _tow);
                }
                else if (x == 2 && z == 2)
                {
                    _bike = new motorbike(_five, _medium, _notTow);
                }
                else if (x == 3 && z == 1)
                {
                    _bike = new motorbike(_five, _large, _tow);
                }
                else if (x == 3 && z == 2)
                {
                    _bike = new motorbike(_five, _large, _notTow);
                }
                else if (x == 4 && z == 1)
                {
                    _bike = new motorbike(_five, _extraLargeStrategy, _tow);
                }
                else if (x == 4 && z == 2)
                {
                    _bike = new motorbike(_five, _extraLargeStrategy, _notTow);
                }
                else
                {
                    Console.WriteLine("Invalid, choose an option from the menu");
                    Console.WriteLine();
                }
            }
            else if (y == 20)
            {
                if (x == 1 && z == 1)
                {
                    _bike = new motorbike(_twenty, _small, _tow);
                }
                else if (x == 1 && z == 2)
                {
                    _bike = new motorbike(_twenty, _small, _notTow);
                }
                else if (x == 2 && z == 1)
                {
                    _bike = new motorbike(_twenty, _medium, _tow);
                }
                else if (x == 2 && z == 2)
                {
                    _bike = new motorbike(_twenty, _medium, _notTow);
                }
                else if (x == 3 && z == 1)
                {
                    _bike = new motorbike(_twenty, _large, _tow);
                }
                else if (x == 3 && z == 2)
                {
                    _bike = new motorbike(_twenty, _large, _notTow);
                }
                else if (x == 4 && z == 1)
                {
                    _bike = new motorbike(_twenty, _extraLargeStrategy, _tow);
                }
                else if (x == 4 && z == 2)
                {
                    _bike = new motorbike(_twenty, _extraLargeStrategy, _notTow);
                }
                else
                {
                    Console.WriteLine("Invalid, choose an option from the menu");
                    Console.WriteLine();
                }
            }
            else if (y == 65)
            {
                if (x == 1 && z == 1)
                {
                    _bike = new motorbike(_sixtyFive, _small, _tow);
                }
                else if (x == 1 && z == 2)
                {
                    _bike = new motorbike(_sixtyFive, _small, _notTow);
                }
                else if (x == 2 && z == 1)
                {
                    _bike = new motorbike(_sixtyFive, _medium, _tow);
                }
                else if (x == 2 && z == 2)
                {
                    _bike = new motorbike(_sixtyFive, _medium, _notTow);
                }
                else if (x == 3 && z == 1)
                {
                    _bike = new motorbike(_sixtyFive, _large, _tow);
                }
                else if (x == 3 && z == 2)
                {
                    _bike = new motorbike(_sixtyFive, _large, _notTow);
                }
                else if (x == 4 && z == 1)
                {
                    _bike = new motorbike(_sixtyFive, _extraLargeStrategy, _tow);
                }
                else if (x == 4 && z == 2)
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
        static Vehicle AssignLightVehicle(char sound, char wifi, char camera, int y, int x, int z,Vehicle _light, GoodDriverStrategy _driver, TwoPeopleStrategy _two, FivePeopleStrategy _five, TwentyPeopleStrategy _twenty, SixtyFivePeopleStrategy _sixtyFive, SmallEngineStrategy _small, MediumEngineStrategy _medium, LargeEngineStrategy _large, ExtraLargeStrategy _extraLargeStrategy, TowStrategy _tow, NotTowStrategy _notTow)
        {
            _light.Name = "light-vehicle";
            WiFi _wifi = new WiFi(_light);
            if (y == 1)
            {
                if (x == 1 && z == 1)
                {
                    _light = new lightvehicle(_driver, _small, _tow);
                }
                else if (x == 1 && z == 2)
                {
                    _light = new lightvehicle(_driver, _small, _notTow);
                }
                else if (x == 2 && z == 1)
                {
                    _light = new lightvehicle(_driver, _medium, _tow);
                }
                else if (x == 2 && z == 2)
                {
                    _light = new lightvehicle(_driver, _medium, _notTow);
                }
                else if (x == 3 && z == 1)
                {
                    _light = new lightvehicle(_driver, _large, _tow);
                }
                else if (x == 3 && z == 2)
                {
                    _light = new lightvehicle(_driver, _large, _notTow);
                }
                else if (x == 4 && z == 1)
                {
                    _light = new lightvehicle(_driver, _extraLargeStrategy, _tow);
                }
                else if (x == 4 && z == 2)
                {
                    _light = new lightvehicle(_driver, _extraLargeStrategy, _notTow);
                }
                else
                {
                    Console.WriteLine("Invalid, choose an option from the menu");
                    Console.WriteLine();
                }
            }
            else if (y == 2)
            {
                if (x == 1 && z == 1)
                {
                    _light = new lightvehicle(_two, _small, _tow);
                }
                else if (x == 1 && z == 2)
                {
                    _light = new lightvehicle(_two, _small, _notTow);
                }
                else if (x == 2 && z == 1)
                {
                    _light = new lightvehicle(_two, _medium, _tow);
                }
                else if (x == 2 && z == 2)
                {
                    _light = new lightvehicle(_two, _medium, _notTow);
                }
                else if (x == 3 && z == 1)
                {
                    _light = new lightvehicle(_two, _large, _tow);
                }
                else if (x == 3 && z == 2)
                {
                    _light = new lightvehicle(_two, _large, _notTow);
                }
                else if (x == 4 && z == 1)
                {
                    _light = new lightvehicle(_two, _extraLargeStrategy, _tow);
                }
                else if (x == 4 && z == 2)
                {
                    _light = new lightvehicle(_two, _extraLargeStrategy, _notTow);
                }
                else
                {
                    Console.WriteLine("Invalid, choose an option from the menu");
                    Console.WriteLine();
                }
            }
            else if (y == 5)
            {
                if (x == 1 && z == 1)
                {
                    _light = new lightvehicle(_five, _small, _tow);
                }
                else if (x == 1 && z == 2)
                {
                    _light = new lightvehicle(_five, _small, _notTow);
                }
                else if (x == 2 && z == 1)
                {
                    _light = new lightvehicle(_five, _medium, _tow);
                }
                else if (x == 2 && z == 2)
                {
                    _light = new lightvehicle(_five, _medium, _notTow);
                }
                else if (x == 3 && z == 1)
                {
                    _light = new lightvehicle(_five, _large, _tow);
                }
                else if (x == 3 && z == 2)
                {
                    _light = new lightvehicle(_five, _large, _notTow);
                }
                else if (x == 4 && z == 1)
                {
                    _light = new lightvehicle(_five, _extraLargeStrategy, _tow);
                }
                else if (x == 4 && z == 2)
                {
                    _light = new lightvehicle(_five, _extraLargeStrategy, _notTow);
                }
                else
                {
                    Console.WriteLine("Invalid, choose an option from the menu");
                    Console.WriteLine();
                }
            }
            else if (y == 20)
            {
                if (x == 1 && z == 1)
                {
                    _light = new lightvehicle(_twenty, _small, _tow);
                }
                else if (x == 1 && z == 2)
                {
                    _light = new lightvehicle(_twenty, _small, _notTow);
                }
                else if (x == 2 && z == 1)
                {
                    _light = new lightvehicle(_twenty, _medium, _tow);
                }
                else if (x == 2 && z == 2)
                {
                    _light = new lightvehicle(_twenty, _medium, _notTow);
                }
                else if (x == 3 && z == 1)
                {
                    _light = new lightvehicle(_twenty, _large, _tow);
                }
                else if (x == 3 && z == 2)
                {
                    _light = new lightvehicle(_twenty, _large, _notTow);
                }
                else if (x == 4 && z == 1)
                {
                    _light = new lightvehicle(_twenty, _extraLargeStrategy, _tow);
                }
                else if (x == 4 && z == 2)
                {
                    _light = new lightvehicle(_twenty, _extraLargeStrategy, _notTow);
                }
                else
                {
                    Console.WriteLine("Invalid, choose an option from the menu");
                    Console.WriteLine();
                }
            }
            else if (y == 65)
            {
                if (x == 1 && z == 1)
                {
                    _light = new lightvehicle(_sixtyFive, _small, _tow);
                }
                else if (x == 1 && z == 2)
                {
                    _light = new lightvehicle(_sixtyFive, _small, _notTow);
                }
                else if (x == 2 && z == 1)
                {
                    _light = new lightvehicle(_sixtyFive, _medium, _tow);
                }
                else if (x == 2 && z == 2)
                {
                    _light = new lightvehicle(  _sixtyFive, _medium, _notTow);
                }
                else if (x == 3 && z == 1)
                {
                    _light = new lightvehicle(_sixtyFive, _large, _tow);
                }
                else if (x == 3 && z == 2)
                {   
                    _light = new lightvehicle(_sixtyFive, _large, _notTow);
                }
                else if (x == 4 && z == 1)
                {
                    _light = new lightvehicle(_sixtyFive, _extraLargeStrategy, _tow);
                }
                else if (x == 4 && z == 2)
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
        static Vehicle AssignHeavyVehicle(char sound, char wifi, char camera, int y, int x, int z, Vehicle _heavy, GoodDriverStrategy _driver, TwoPeopleStrategy _two, FivePeopleStrategy _five, TwentyPeopleStrategy _twenty, SixtyFivePeopleStrategy _sixtyFive, SmallEngineStrategy _small, MediumEngineStrategy _medium, LargeEngineStrategy _large, ExtraLargeStrategy _extraLargeStrategy, TowStrategy _tow, NotTowStrategy _notTow)
        {
            _heavy.Name = "heavy-vehicle";
            WiFi _wifi= new WiFi(_heavy);
            if (y == 1)
            {
                if (x == 1 && z == 1)
                {
                    _heavy = new heavyvehicle(_driver, _small, _tow);
                }
                else if (x == 1 && z == 2)
                {
                    _heavy = new heavyvehicle(_driver, _small, _notTow);
                }
                else if (x == 2 && z == 1)
                {
                    _heavy = new heavyvehicle(_driver, _medium, _tow);
                }
                else if (x == 2 && z == 2)
                {
                    _heavy = new heavyvehicle(_driver, _medium, _notTow);
                }
                else if (x == 3 && z == 1)
                {
                    _heavy = new heavyvehicle(_driver, _large, _tow);
                }
                else if (x == 3 && z == 2)
                {
                    _heavy = new heavyvehicle(_driver, _large, _notTow);
                }
                else if (x == 4 && z == 1)
                {
                    _heavy = new heavyvehicle(_driver, _extraLargeStrategy, _tow);
                }
                else if (x == 4 && z == 2)
                {
                    _heavy = new heavyvehicle(_driver, _extraLargeStrategy, _notTow);
                }
                else
                {
                    Console.WriteLine("Invalid, choose an option from the menu");
                    Console.WriteLine();
                }
            }
            else if (y == 2)
            {
                if (x == 1 && z == 1)
                {
                    _heavy = new heavyvehicle(_two, _small, _tow);
                }
                else if (x == 1 && z == 2)
                {
                    _heavy = new heavyvehicle(_two, _small, _notTow);
                }
                else if (x == 2 && z == 1)
                {
                    _heavy = new heavyvehicle(_two, _medium, _tow);
                }
                else if (x == 2 && z == 2)
                {
                    _heavy = new heavyvehicle(_two, _medium, _notTow);
                }
                else if (x == 3 && z == 1)
                {
                    _heavy = new heavyvehicle(_two, _large, _tow);
                }
                else if (x == 3 && z == 2)
                {
                    _heavy = new heavyvehicle(_two, _large, _notTow);
                }
                else if (x == 4 && z == 1)
                {
                    _heavy = new heavyvehicle(_two, _extraLargeStrategy, _tow);
                }
                else if (x == 4 && z == 2)
                {
                    _heavy = new heavyvehicle(_two, _extraLargeStrategy, _notTow);
                }
                else
                {
                    Console.WriteLine("Invalid, choose an option from the menu");
                    Console.WriteLine();
                }
            }
            else if (y == 5)
            {
                if (x == 1 && z == 1)
                {
                    _heavy = new heavyvehicle(_five, _small, _tow);
                }
                else if (x == 1 && z == 2)
                {
                    _heavy = new heavyvehicle(_five, _small, _notTow);
                }   
                else if (x == 2 && z == 1)
                {
                    _heavy = new heavyvehicle(_five, _medium, _tow);
                }
                else if (x == 2 && z == 2)
                {
                    _heavy = new heavyvehicle(_five, _medium, _notTow);
                }
                else if (x == 3 && z == 1)
                {
                    _heavy = new heavyvehicle(_five, _large, _tow);
                }
                else if (x == 3 && z == 2)
                {
                    _heavy = new heavyvehicle(_five, _large, _notTow);
                }
                else if (x == 4 && z == 1)
                {
                    _heavy = new heavyvehicle(_five, _extraLargeStrategy, _tow);
                }
                else if (x == 4 && z == 2)
                {
                    _heavy = new heavyvehicle(_five, _extraLargeStrategy, _notTow);
                }
                else
                {
                    Console.WriteLine("Invalid, choose an option from the menu");
                    Console.WriteLine();
                }
            }
            else if (y == 20)
            {
                if (x == 1 && z == 1)
                {
                    _heavy = new heavyvehicle(_twenty, _small, _tow);
                }
                else if (x == 1 && z == 2)
                {
                    _heavy = new heavyvehicle(_twenty, _small, _notTow);
                }
                else if (x == 2 && z == 1)
                {   
                    _heavy = new heavyvehicle(_twenty, _medium, _tow);
                }
                else if (x == 2 && z == 2)
                {
                    _heavy = new heavyvehicle(_twenty, _medium, _notTow);
                }
                else if (x == 3 && z == 1)
                {
                    _heavy = new heavyvehicle(_twenty, _large, _tow);
                }
                else if (x == 3 && z == 2)
                {
                    _heavy = new heavyvehicle(_twenty, _large, _notTow);
                }
                else if (x == 4 && z == 1)
                {
                    _heavy = new heavyvehicle(_twenty, _extraLargeStrategy, _tow);
                }
                else if (x == 4 && z == 2)
                {
                    _heavy = new heavyvehicle(_twenty, _extraLargeStrategy, _notTow);
                }
                else
                {
                    Console.WriteLine("Invalid, choose an option from the menu");
                    Console.WriteLine();
                }
            }
            else if (y == 65)
            {
                if (x == 1 && z == 1)
                {
                    _heavy = new heavyvehicle(_sixtyFive, _small, _tow);
                }
                else if (x == 1 && z == 2)
                {
                    _heavy = new heavyvehicle(_sixtyFive, _small, _notTow);
                }
                else if (x == 2 && z == 1)
                {
                    _heavy = new heavyvehicle(_sixtyFive, _medium, _tow);
                }
                else if (x == 2 && z == 2)
                {
                    _heavy = new heavyvehicle( _sixtyFive, _medium, _notTow);
                }
                else if (x == 3 && z == 1)
                {
                    _heavy = new heavyvehicle(_sixtyFive, _large, _tow);
                }
                else if (x == 3 && z == 2)
                {
                    _heavy = new heavyvehicle(_sixtyFive, _large, _notTow);
                }
                else if (x == 4 && z == 1)
                {
                    _heavy = new heavyvehicle(_sixtyFive, _extraLargeStrategy, _tow);
                }
                else if (x == 4 && z == 2)
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
            string[] motoTech ={ "John", "Smith" };
            string[] HeavyLightTech = { "Lisa", "Sam" };
            int count = 2;
            Console.Write("Do you want to add a new technician (y/n): ");
            char newTechnician=char.Parse(Console.ReadLine());
            if(newTechnician == 'Y'|| newTechnician == 'y')
            {
                Console.Write("How many technician do you want to add: ");
                int TechnicianNumber=int.Parse(Console.ReadLine());
                for(int i=0; i<=TechnicianNumber; i++)
                {
                    Console.Write("Enter the name of a technician you would also like update: ");
                    string techName = Console.ReadLine();
                    if(type== 1)
                    {
                        motoTech[count] = techName;
                    }
                    else if(type== 2 ||type==3)
                    {
                        HeavyLightTech[count] = techName;
                    }
                    count=count+1;
                } 
            }
            if (type == 1)
            {
                for(int x = 0; x < motoTech.Length; x = x+1)
                {
                    motobikeTech _motoTech = new motobikeTech(motoTech[x]);
                    _wifi.AddTechnician(_motoTech, type);
                }
               
                Console.WriteLine();
            }
            else if (type == 2 || type == 3)
            {
                for (int x = 0; x < HeavyLightTech.Length; x = x + 1)
                {
                    HeavyLightTech _heavylightTech = new HeavyLightTech(HeavyLightTech[x]);
                    _wifi.AddTechnician(_heavylightTech, type);
                }
                Console.WriteLine();
            }
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
    //Strategy pattern:
    //Carrier capabilities
    public interface ICarrierCapability
    {
        string DefineCapability();
    }
    public class GoodDriverStrategy : ICarrierCapability
    {
        public string DefineCapability()
        {
            return "Good and Driver.";
        }
    }
    public class TwoPeopleStrategy : ICarrierCapability
    {
        public string DefineCapability()
        {
            return "2 people max and bag.";
        }
    }
    public class FivePeopleStrategy : ICarrierCapability
    {
        public string DefineCapability()
        {
            return "5 people max and few luggage.";
        }
    }
    public class TwentyPeopleStrategy : ICarrierCapability
    {
        public string DefineCapability()
        {
            return "20 people max.";
        }
    }
    public class SixtyFivePeopleStrategy : ICarrierCapability
    {
        public string DefineCapability()
        {
            return "65 people max.";
        }
    }
    //Engine
    public interface IEngine
    {
        string DefineEngine();
    }
    public class SmallEngineStrategy : IEngine
    {
        public string DefineEngine()
        {
            return "Small engine.";
        }
    }
    public class MediumEngineStrategy : IEngine
    {
        public  string DefineEngine()
        {
            return "Medium engine.";
        }
    }
    public class LargeEngineStrategy : IEngine
    {
        public string DefineEngine()
        {
            return "Large engine.";
        }
    }
    public class ExtraLargeStrategy : IEngine
    {
        public string DefineEngine()
        {
            return "Extra large engine.";
        }
    }
    //Towing capabilities
    public interface ITowingCapability
    {
        string DefineTowingCapability();
    }
    public class TowStrategy : ITowingCapability
    {
        public string DefineTowingCapability()
        {
            return "can tow.";
        }
    }
    public class NotTowStrategy : ITowingCapability
    {
        public string DefineTowingCapability()
        {
            return "cannot tow.";
        }
    }
    
    //Decorator pattern
    public abstract class Vehicle
    {
        public string Name { get; set; }
        public abstract string Description();
        public abstract double Cost(int vehicleType);
    }
    public class motorbike : Vehicle
    {
        public ICarrierCapability _carrier { get; set; }
        public IEngine _engine { get; set; }
        public ITowingCapability _tow { get; set; }
        public motorbike(ICarrierCapability carrier, IEngine engine, ITowingCapability tow)
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
        public override double Cost(int vehicleType)
        {
            return 4.00;
        }
    }
    public class lightvehicle : Vehicle
    {
        public ICarrierCapability _carrier { get; set; }
        public IEngine _engine { get; set; }
        public ITowingCapability _tow { get; set; }
        public lightvehicle(ICarrierCapability carrier, IEngine engine, ITowingCapability tow)
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
        public override double Cost(int vehicleType)
        {
            return 5.00;
        }
    }
    public class heavyvehicle : Vehicle 
    {
        public ICarrierCapability _carrier { get; set; }
        public IEngine _engine { get; set; }
        public ITowingCapability _tow { get; set; }
        public heavyvehicle(ICarrierCapability carrier, IEngine engine, ITowingCapability tow)
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
        public override double Cost(int vehicleType)
        {
            return 1.00;
        }
    }
    public abstract class VehicleDecorator : Vehicle
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
        public override double Cost(int vehicleType)
        {
            return _vehicle.Cost(vehicleType);
        }
    }
    public class Sound : VehicleDecorator 
    {
        Vehicle _vehicle;
        
        public Sound(Vehicle vehicle):base(vehicle)
        {
            _vehicle = vehicle;
        }
        public override string Description()
        {
             return _vehicle.Description()+ "\nAdded sound system";
        }
        public string AddSound()
        {
            return "\nSound system added";
        }
        public override double Cost(int vehicleType)
        {
            double totalCost=0;
            if (vehicleType == 1) 
            {
                totalCost= _vehicle.Cost(vehicleType) + 1;
            }
            else if(vehicleType == 2)
            {
                totalCost = _vehicle.Cost(vehicleType) + 12;
            }
            else if(vehicleType == 3)
            {
                totalCost = _vehicle.Cost(vehicleType) + 14;
            }
            return totalCost;
        }
    }
    public interface IObserver
    {
        void Update(string message);
    }
    public interface IWifi
    {
        void AddTechnician(IObserver technician, int name);
        void RemoveTechnician(IObserver technician);
        void Notify(string message, string name);
    }
    public class WiFi : VehicleDecorator, IWifi 
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
        public override double Cost(int vehicleType)
        {
            double totalCost = 0;
            if (vehicleType == 1)
            {
                totalCost = _vehicle.Cost(vehicleType) + 7;
            }
            else if (vehicleType == 2)
            {
                totalCost = _vehicle.Cost(vehicleType) + 9;
            }
            else if (vehicleType ==3)
            {
                totalCost = _vehicle.Cost(vehicleType) + 1;
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
        public void GetState(string message)
        {
            NewMessage = "The "+_vehicle.Name+" "+message;
            Notify(NewMessage, _vehicle.Name);
        }
    }
    public class Camera : VehicleDecorator
    {
        Vehicle _vehicle;
        public Camera(Vehicle vehicle):base(vehicle)
        {
            _vehicle = vehicle;
        }
        public override string Description()
        {
            return _vehicle.Description()+ AddCamera();  
        }
        public string AddCamera()
        {
            return "\nCamera added";
        }
        public override double Cost(int vehicleType)
        {
            double totalCost = 0;
            if (vehicleType == 1)
            {
                totalCost = _vehicle.Cost(vehicleType) + 2;
            }
            else if (vehicleType == 2)
            {
                totalCost = _vehicle.Cost(vehicleType) + 4;
            }
            else if (vehicleType == 3)
            {
                totalCost = _vehicle.Cost(vehicleType) + 6;
            }
            return totalCost;
        }
    }
    //Observer pattern
    public class motobikeTech:IObserver
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
    public class HeavyLightTech : IObserver
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
