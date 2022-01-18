using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableTypesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //int age = null;
            //Nullable<int> age = null;
            int? age = null;
            int? salary = 50000;

            //Console.WriteLine("Age = " + age.Value);
            //Console.WriteLine("Age = " + age.GetValueOrDefault());

            if (salary.HasValue)
            {
                Console.WriteLine("Salary = " + salary.Value);
            }
            else
            {
                Console.WriteLine("Salary not defined");
            }

            Console.ReadKey();

        }
    }
}
