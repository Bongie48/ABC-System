using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
            List<GetCarrier>_carrierList= new List<GetCarrier>();
            SmallEngineStrategy _small= new SmallEngineStrategy();
            MediumEngineStrategy _medium= new MediumEngineStrategy();
            LargeEngineStrategy _large= new LargeEngineStrategy();
            ExtraLargeStrategy _extraLargeStrategy= new ExtraLargeStrategy();
            TowStrategy _tow= new TowStrategy();
            NotTowStrategy _notTow= new NotTowStrategy();
            Connector _con = new Connector(_driver, _small, _tow);
            char sound = 'c';
            char wifi = 'c';
            char camera='c';
            
            _carrierList.Add(new GetCarrier(_driver));
            _carrierList.Add(new GetCarrier(_two));
            _carrierList.Add(new GetCarrier(_five));
            _carrierList.Add(new GetCarrier(_twenty));
            _carrierList.Add(new GetCarrier(_sixtyFive));
            Console.WriteLine("Choose one choice from each option\nA. Carrier capabilities:\n=========================");
            
            foreach (GetCarrier carrier in _carrierList)
            {
                carrier.DisplayOptions();
            }
            Console.WriteLine();
            List<GetEngineStrategy>_engineList= new List<GetEngineStrategy>();
            _engineList.Add(new GetEngineStrategy(_small));
            _engineList.Add(new GetEngineStrategy(_medium));
            _engineList.Add(new GetEngineStrategy(_large));
            _engineList.Add(new GetEngineStrategy(_extraLargeStrategy));
            Console.WriteLine("B. Engine\n==========");
            
            foreach (GetEngineStrategy engine in _engineList)
            {
                engine.DisplayOptions();
            }
            Console.WriteLine();
            List<GetTowStrategy>_towList= new List<GetTowStrategy>();
            _towList.Add(new GetTowStrategy(_tow));
            _towList.Add(new GetTowStrategy(_notTow));
            Console.WriteLine("C.Towing capabilities\n======================");
            
            foreach (GetTowStrategy tow in _towList)
            {
                tow.DisplayOptions();
            }
            Console.WriteLine();
            Console.Write("Which vehicle do you want (1/2/3): ");
            int vehicle=int.Parse(Console.ReadLine());
            Console.Write("Enter a carrier capability (1,2,5,20,65): ");
            int y=int.Parse(Console.ReadLine());
            Console.Write("Enter engine option (1,2,3,4): ");
            int x=int.Parse(Console.ReadLine());
            Console.Write("Enter tow capability (1,2): ");
            int z=int.Parse(Console.ReadLine());

            Console.Write("Do you want to add extra specs (y/n): ");
            char extraSpec=char.Parse(Console.ReadLine());

            if (extraSpec == 'y' || extraSpec == 'Y')
            {
                Console.Write("Do you want to add sound (y/n): ");
                sound=char.Parse(Console.ReadLine());
                Console.Write("Do you want to add wi-fi (y/n): ");
                wifi=char.Parse(Console.ReadLine());
                Console.Write("Do you want to add camera (y/n): ");
                camera=char.Parse(Console.ReadLine());

            }
            
            Console.WriteLine() ;
            
            if (y == 1)
            {
                if(x== 1 && z == 1)
                {
                    _con= new Connector(_driver, _small, _tow);
                }
                else if(x==1 && z == 2)
                {
                    _con=new Connector(_driver, _small, _notTow);
                }
                else if (x == 2 && z == 1)
                {
                    _con=new Connector(_driver,_medium, _tow);
                }
                else if(x == 2 && z == 2)
                {
                    _con=new Connector(_driver,_medium,_notTow);
                }
                else if(x==3&&z == 1)
                {
                    _con = new Connector(_driver, _large, _tow);
                }
                else if(x==3&& z == 2)
                {
                    _con=new Connector(_driver,_large, _notTow);
                }
                else if(x==4&&z==1)
                {
                    _con=new Connector(_driver,_extraLargeStrategy, _tow);
                }
                else if(x==4&&z== 2)
                {
                    _con = new Connector(_driver, _extraLargeStrategy, _notTow);
                }
            }
            else if (y == 2)
            {
                if (x == 1 && z == 1)
                {
                    _con = new Connector(_two, _small, _tow);
                }
                else if (x == 1 && z == 2)
                {
                    _con = new Connector(_two, _small, _notTow);
                }
                else if (x == 2 && z == 1)
                {
                    _con = new Connector(_two, _medium, _tow);
                }
                else if (x == 2 && z == 2)
                {
                    _con = new Connector(_two, _medium, _notTow);
                }
                else if (x == 3 && z == 1)
                {
                    _con = new Connector(_two, _large, _tow);
                }
                else if (x == 3 && z == 2)
                {
                    _con = new Connector(_two, _large, _notTow);
                }
                else if (x == 4 && z == 1)
                {
                    _con = new Connector(_two, _extraLargeStrategy, _tow);
                }
                else if (x == 4 && z == 2)
                {
                    _con = new Connector(_two, _extraLargeStrategy, _notTow);
                }
            }
            else if (y == 5)
            {
                if (x == 1 && z == 1)
                {
                    _con = new Connector(_five, _small, _tow);
                }
                else if (x == 1 && z == 2)
                {
                    _con = new Connector(_five, _small, _notTow);
                }
                else if (x == 2 && z == 1)
                {
                    _con = new Connector(_five, _medium, _tow);
                }
                else if (x == 2 && z == 2)
                {
                    _con = new Connector(_five, _medium, _notTow);
                }
                else if (x == 3 && z == 1)
                {
                    _con = new Connector(_five, _large, _tow);
                }
                else if (x == 3 && z == 2)
                {
                    _con = new Connector(_five, _large, _notTow);
                }
                else if (x == 4 && z == 1)
                {
                    _con = new Connector(_five, _extraLargeStrategy, _tow);
                }
                else if (x == 4 && z == 2)
                {
                    _con = new Connector(_five, _extraLargeStrategy, _notTow);
                }
            }
            if (y == 20)
            {
                if (x == 1 && z == 1)
                {
                    _con = new Connector(_twenty, _small, _tow);
                }
                else if (x == 1 && z == 2)
                {
                    _con = new Connector(_twenty, _small, _notTow);
                }
                else if (x == 2 && z == 1)
                {
                    _con = new Connector(_twenty, _medium, _tow);
                }
                else if (x == 2 && z == 2)
                {
                    _con = new Connector(_twenty, _medium, _notTow);
                }
                else if (x == 3 && z == 1)
                {
                    _con = new Connector(_twenty, _large, _tow);
                }
                else if (x == 3 && z == 2)
                {
                    _con = new Connector(_twenty, _large, _notTow);
                }
                else if (x == 4 && z == 1)
                {
                    _con = new Connector(_twenty, _extraLargeStrategy, _tow);
                }
                else if (x == 4 && z == 2)
                {
                    _con = new Connector(_twenty, _extraLargeStrategy, _notTow);
                }
            }
            else if (y == 65)
            {
                if (x == 1 && z == 1)
                {
                    _con = new Connector(_sixtyFive, _small, _tow);
                }
                else if (x == 1 && z == 2)
                {
                    _con = new Connector(_sixtyFive, _small, _notTow);
                }
                else if (x == 2 && z == 1)
                {
                    _con = new Connector(_sixtyFive, _medium, _tow);
                }
                else if (x == 2 && z == 2)
                {
                    _con = new Connector(_sixtyFive, _medium, _notTow);
                }
                else if (x == 3 && z == 1)
                {
                    _con = new Connector(_sixtyFive, _large, _tow);
                }
                else if (x == 3 && z == 2)
                {
                    _con = new Connector(_sixtyFive, _large, _notTow);
                }
                else if (x == 4 && z == 1)
                {
                    _con = new Connector(_sixtyFive, _extraLargeStrategy, _tow);
                }
                else if (x == 4 && z == 2)
                {
                    _con = new Connector(_sixtyFive, _extraLargeStrategy, _notTow);
                }
            }
            //_con.CallStrategyMethods();
            _con.VehicleDescripton(vehicle, sound, wifi, camera);
           
            Console.ReadKey();
        }
    }
    //Strategy pattern:
    //Carrier capabilities
    public abstract class CarrierCapability
    {
        public abstract string DefineCapability();
    }
    public class GoodDriverStrategy : CarrierCapability
    {
        public override string DefineCapability()
        {
            return "Good and Driver.";
        }
    }
    public class TwoPeopleStrategy : CarrierCapability
    {
        public override string DefineCapability()
        {
            return "2 people max and bag.";
        }
    }
    public class FivePeopleStrategy : CarrierCapability
    {
        public override string DefineCapability()
        {
            return "5 people max and few luggage.";
        }
    }
    public class TwentyPeopleStrategy : CarrierCapability
    {
        public override string DefineCapability()
        {
            return "20 people max.";
        }
    }
    public class SixtyFivePeopleStrategy : CarrierCapability
    {
        public override string DefineCapability()
        {
            return "65 people max.";
        }
    }
    //Engine
    public abstract class Engine
    {
        public abstract string DefineEngine();
    }
    public class SmallEngineStrategy : Engine
    {
        public override string DefineEngine()
        {
            return "Small engine.";
        }
    }
    public class MediumEngineStrategy : Engine
    {
        public override string DefineEngine()
        {
            return "Medium engine.";
        }
    }
    public class LargeEngineStrategy : Engine
    {
        public override string DefineEngine()
        {
            return "Large engine.";
        }
    }
    public class ExtraLargeStrategy : Engine
    {
        public override string DefineEngine()
        {
            return "Extra large engine.";
        }
    }
    //Towing capabilities
    public abstract class TowingCapability
    {
        public abstract string DefineTowingCapability();
    }
    public class TowStrategy : TowingCapability
    {
        public override string DefineTowingCapability()
        {
            return "can tow.";
        }
    }
    public class NotTowStrategy : TowingCapability
    {
        public override string DefineTowingCapability()
        {
            return "cannot tow.";
        }
    }
    public class GetCarrier 
    {
        public CarrierCapability _carrier { get; set; }
        public GetCarrier(CarrierCapability carrier)
        {
            this._carrier = carrier;
        }
        public void DisplayOptions()
        { 
            Console.WriteLine(_carrier.DefineCapability());
        }
    }
    public class GetEngineStrategy
    {
        public Engine _engine { get; set; }
        public GetEngineStrategy(Engine engine)
        {
            this._engine = engine;
        }
        public void DisplayOptions()
        { 
            Console.WriteLine(_engine.DefineEngine());
        }
    }
    public class GetTowStrategy
    {
        public TowingCapability _towing { get; set; }
        public GetTowStrategy(TowingCapability towing)
        {
            _towing = towing;
        }
        public void DisplayOptions()
        {
            Console.WriteLine(_towing.DefineTowingCapability());
        }
    }

    //Client that accesses every strategy class
    public class Connector
    {
        //Strategy
        public CarrierCapability _carrier { get; set; }
        public Engine _engine { get; set; }
        public TowingCapability _tow { get; set; }
        //Decorator
        Vehicle _motobike = new motorbike();
        Vehicle _light = new lightvehicle();
        Vehicle _heavy = new heavyvehicle();
        //Observer
        concreteWifi _wifi=new concreteWifi();
        
        public Connector(CarrierCapability carrier, Engine engine, TowingCapability tow)
        {
            this._carrier = carrier;
            this._engine = engine;
            this._tow = tow;
        }
        public void technician( string name,int type)
        {
            if (type == 1)
            {
                motobikeTech _motoTech = new motobikeTech(name);
                _wifi.AddTechnician(_motoTech,type);
                Console.WriteLine("Technician added successfully.");
            }
            if(type == 2||type==3)
            {
                HeavyLightTech _heavylightTech = new HeavyLightTech(name);
                _wifi.AddTechnician(_heavylightTech,type);
                Console.WriteLine("Technician added successfully.");
            }
        }
        
        public void VehicleDescripton(int name,char sound,int wifi,int camera)
        {
            string GetCarrier = _carrier.DefineCapability();
            string GetEngine = _engine.DefineEngine();
            string GetTow = _tow.DefineTowingCapability();
            string techName = "";
            if (name == 1)
            {
                
               
                if (sound == 'Y' || sound == 'y')
                {
                    _motobike = new Sound(_motobike);
                }
                if (wifi == 'Y' || wifi == 'y')
                {
                    Console.Write("Enter technician to update: ");
                    techName = Console.ReadLine();
                    technician(techName, name);
                    _wifi.GetUpdate(name, "perform diagnostics or provide daily news about specials at ABC systems ");
                    if (sound == 'y' || sound == 'Y')
                    {
                        Console.WriteLine(", and also update the sound system.");
                    }
                    else
                    {
                        Console.WriteLine(" ");
                    }
                    _motobike =new WiFi(_motobike);
                }
                if(camera == 'Y' || camera == 'y')
                {
                    _motobike=new Camera(_motobike);
                }
            }
            
            else if (name == 2)
            {
                
                if (sound == 'Y' || sound == 'y')
                {
                    _light = new Sound(_light);
                }
                if (wifi == 'Y' || wifi == 'y')
                {
                    Console.Write("Enter technician to update: ");
                    techName = Console.ReadLine();
                    technician(techName, name);
                    _wifi.GetUpdate(name, "perform diagnostics or provide daily news about specials at ABC systems ");
                    if (sound == 'y' || sound == 'Y')
                    {
                        Console.WriteLine(", and also update the sound system.");
                    }
                    else
                    {
                        Console.WriteLine(" ");
                    }
                    _light = new WiFi(_light);
                }
                if (camera == 'Y' || camera == 'y')
                {
                    _light = new Camera(_light);
                }
            }
            else if (name == 3)
            {
                if (sound == 'Y' || sound == 'y')
                {
                    _heavy = new Sound(_heavy);
                }
                if (wifi == 'Y' || wifi == 'y')
                {
                    Console.Write("Enter technician to update: ");
                    techName = Console.ReadLine();
                    technician(techName, name);
                    _wifi.GetUpdate(name, "perform diagnostics or provide daily news about specials at ABC systems ");
                    if (sound == 'y' || sound == 'Y')
                    {
                        Console.WriteLine(", and also update the sound system.");
                    }
                    else
                    {
                        Console.WriteLine(" ");
                    }
                    _heavy = new WiFi(_heavy);
                }
                if (camera == 'Y' || camera == 'y')
                {
                    _heavy = new Camera(_heavy);
                }
            }
            Console.WriteLine($"Your vehicle has the following specs:\n1. {GetCarrier}\n2. {GetEngine}\n3. {GetTow}");
            if ((sound == 'y' || sound == 'Y') || (wifi == 'Y' || wifi == 'y') || (camera == 'y' || camera == 'Y')) 
            {
                Console.WriteLine();
                Console.WriteLine("Extra added specs:\n==================");
                if (_motobike != null && name==1)
                {
                    Console.WriteLine($"{_motobike.Description()} :\t{_motobike.Cost(name).ToString("C")}");
                }
                if (_light != null && name==2)
                {
                    Console.WriteLine($"{_light.Description()} :\t{_light.Cost(name).ToString("C")}");
                }
                if (_heavy != null && name==3)
                {
                    Console.WriteLine($"{_heavy.Description()} :\t{_heavy.Cost(name).ToString("C")}");
                }
            }
            
        }
    }
    //Decorator pattern
    public abstract class Vehicle
    {
        public abstract string Description();
        public abstract double Cost(int vehicleType);
    }
    public class motorbike : Vehicle
    {
        public override string Description()
        {
            return "Motobike";
        }
        public override double Cost(int vehicleType)
        {
            return 4.00;
        }
    }
    public class lightvehicle : Vehicle
    {
        public override string Description()
        {
            return "Light vehicle";
        }
        public override double Cost(int vehicleType)
        {
            return 5.00;
        }
    }
    public class heavyvehicle : Vehicle 
    { 
        public override string Description()
        {
            return "Heavy vehicle";
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
        Vehicle _vehicle = null;
        public Sound(Vehicle vehicle):base(vehicle)
        {
            _vehicle = vehicle;
        }
        public override string Description()
        {
            
            return _vehicle.Description()+", Added sound system";
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
    public class WiFi : VehicleDecorator
    {
        Vehicle _vehicle= null;
        public WiFi(Vehicle vehicle):base(vehicle)
        {
            _vehicle= vehicle;
        }
        public override string Description()
        {
            return _vehicle.Description()+", Added wifi";
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
    }
    public class Camera : VehicleDecorator
    {
        Vehicle _vehicle = null;
        public Camera(Vehicle vehicle):base(vehicle)
        {
            _vehicle = vehicle;
        }
        public override string Description()
        {
            return _vehicle.Description()+ ", Added camera ";
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
    public interface IObserver
    {
        void Update(string message);
    }
    public abstract class WifiConnection
    {
        private List<IObserver> _motolist= new List<IObserver>();
        private List<IObserver> _heavyLightList= new List<IObserver>();
        public void AddTechnician(IObserver technician,int name)
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
        public void Notify(string message,int name)
        {
            if (name == 1)
            {
                foreach (IObserver _tech in _motolist)
                {
                    _tech.Update(message);
                }
            }
            else if(name == 2 || name == 3)
            {
                foreach (IObserver _tech in _heavyLightList)
                {
                    _tech.Update(message);
                }
            }
        }
        public abstract void GetUpdate(int name, string newMessage);
    }
   
    public class concreteWifi : WifiConnection
    {
        private int Name;
        private string NewMessage;
        public int name { get { return Name; } }
        public string newMessage { get { return NewMessage; } }
        public override void GetUpdate(int name, string newMessage)
        {
            Name = name;
            NewMessage = newMessage;
            Notify($"{Name}\t{NewMessage}",Name);
        }
    }
    public class motobikeTech:IObserver
    {
        private string Name;
        public motobikeTech(string name)
        {
            Name = name;
        }
        public void Update(string newMessage)
        {
            Console.Write($"{Name}\t{newMessage}");
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
            Console.Write($"{Name}\t{newMessage}");
        }
    }
}
