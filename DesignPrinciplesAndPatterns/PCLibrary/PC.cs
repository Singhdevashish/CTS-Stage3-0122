using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PCLibrary
{
    public class PC
    {
        public string Name { get; set; }
        private List<Peripheral> peripherals;
        public PC()
        {
            peripherals = new List<Peripheral>();
        }

        public void AddPeripheral(Peripheral peripheral)
        {
            peripherals.Add(peripheral);
        }
        public string GetSpecification()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var peripheral in peripherals)
                stringBuilder.AppendLine(peripheral.Name);
            return stringBuilder.ToString();
        }
        public double Cost
        {
            get
            {
                return peripherals.Sum(s => s.Cost);
            }
        }

    }
}
