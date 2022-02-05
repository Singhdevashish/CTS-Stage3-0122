using System;
using CalenderLib;
namespace CalenderLibClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var months = new Months();
            var m = months[2];
            Console.WriteLine("Total months : " + months.Count);
            Console.WriteLine(m.No + "\t" + m.Name);

            //for (int i = 1; i <= months.Count; i++)
            //    Console.WriteLine(months[i].No + "\t" + months[i].Name);

            var iterator = months.GetIterator();
            while (iterator.IsDone() != false)
            {
                var current = iterator.Current;
                Console.WriteLine(current.No + "\t" + current.Name);
                iterator.Next();
            }


            foreach (var mn in months)
                Console.WriteLine(mn.No + "\t" + mn.Name);


            Console.ReadKey();
        }
    }
}
