using System;
using PCLibrary;
namespace PCLibraryClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //var homePC = new PC();
            //homePC.AddPeripheral(new Peripheral { Name = "4GB RAM", Cost = 3000 });
            //homePC.AddPeripheral(new Peripheral { Name = "500GB HDD", Cost = 5000 });
            ////homePC.AddPeripheral(new Peripheral { Name = "i3 Processor", Cost = 10000 });
            //homePC.AddPeripheral(new Peripheral { Name = "Inter MB", Cost = 7000 });
            //homePC.AddPeripheral(new Peripheral { Name = "MM Keyboard", Cost = 1000 });
            //homePC.AddPeripheral(new Peripheral { Name = "Optical Mouse", Cost = 500 });
            //homePC.AddPeripheral(new Peripheral { Name = "Monitor 17Inch", Cost = 8000 });
            //homePC.AddPeripheral(new Peripheral { Name = "Normal Speakers", Cost = 1500 });

            //Console.WriteLine(homePC.GetSpecification());
            //Console.WriteLine(homePC.Cost);

            var maker = new GamingPCMaker();
            var director = new PCBuildDirector(maker);
            var pc = director.Build();
            Console.WriteLine(pc.GetSpecification());
            Console.WriteLine(pc.Cost);

            var maker1 = new HomePCMaker();
            var director1 = new PCBuildDirector(maker1);
            var pc1 = director1.Build();
            Console.WriteLine(pc1.GetSpecification());
            Console.WriteLine(pc1.Cost);
        }
    }
}
