using System;
using System.Collections.Generic;
using System.Text;

namespace PCLibrary
{
    public abstract class PCMaker
    {
        protected PC _pc;
        public void CreatePC()
        {
            _pc = new PC();
        }
        public PC GetPC()
        {
            return _pc;
        }
        public abstract void AssemblePC();
        public abstract void AddIODevices();
    }

    public class GamingPCMaker : PCMaker
    {
        public override void AddIODevices()
        {
            _pc.AddPeripheral(new Peripheral { Name = "Mech Keyboard", Cost = 12000 });
            _pc.AddPeripheral(new Peripheral { Name = "MX Master", Cost = 8000 });
            _pc.AddPeripheral(new Peripheral { Name = "Logitech Headphone", Cost = 6000 });
        }

        public override void AssemblePC()
        {
            _pc.AddPeripheral(new Peripheral { Name = "i9 Processor", Cost = 30000 });
            _pc.AddPeripheral(new Peripheral { Name = "Inter MB", Cost = 25000 });
            _pc.AddPeripheral(new Peripheral { Name = "32 GB", Cost = 12000 });
            _pc.AddPeripheral(new Peripheral { Name = "1 TB SSD", Cost = 10000 });
            _pc.AddPeripheral(new Peripheral { Name = "8GB Graphics", Cost = 10000 });
            _pc.AddPeripheral(new Peripheral { Name = "Cooling System", Cost = 4000 });
            _pc.AddPeripheral(new Peripheral { Name = "RGB Case", Cost = 5000 });
        }
    }

    public class HomePCMaker : PCMaker
    {
        public override void AddIODevices()
        {
            _pc.AddPeripheral(new Peripheral { Name = "MM Keyboard", Cost = 1200 });
            _pc.AddPeripheral(new Peripheral { Name = "Optical Mouse", Cost = 800 });
            _pc.AddPeripheral(new Peripheral { Name = "Zebronics Headphone", Cost = 2000 });
        }

        public override void AssemblePC()
        {
            _pc.AddPeripheral(new Peripheral { Name = "i5 Processor", Cost = 12000 });
            _pc.AddPeripheral(new Peripheral { Name = "Inter MB", Cost = 8000 });
            _pc.AddPeripheral(new Peripheral { Name = "8 GB", Cost = 6000 });
            _pc.AddPeripheral(new Peripheral { Name = "1 TB SSD", Cost = 10000 });
            _pc.AddPeripheral(new Peripheral { Name = "2GB Graphics", Cost = 2000 });
            _pc.AddPeripheral(new Peripheral { Name = "Cooling System", Cost = 500 });
            _pc.AddPeripheral(new Peripheral { Name = "ATX Case", Cost = 1500 });
        }
    }

    public class PCBuildDirector
    {
        private readonly PCMaker maker;
        public PCBuildDirector(PCMaker pCMaker)
        {
            this.maker = pCMaker;
        }
        public PC Build()
        {
            maker.CreatePC();
            maker.AssemblePC();
            maker.AddIODevices();
            return maker.GetPC();
        }
    }
}
