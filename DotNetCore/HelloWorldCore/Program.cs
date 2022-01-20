using System;

namespace HelloWorldCore
{
    class Program
    {
        static void Main(string[] args)
        {
            string name=string.Empty;
            Console.WriteLine("Enter your name");
            name = Console.ReadLine();

            int age =0;
            Console.WriteLine("Enter your age");
            age= Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"{name} is {age} years old");
        }
    }
}
