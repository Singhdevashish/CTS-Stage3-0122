using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionalParameters
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintDocument("Profile.pdf", 2, false);
            PrintDocument("Profile.pdf");
            PrintDocument("nUnit.pptx", 3);

            PrintDocument(fileName: "CSharpFeatures.pptx", useColor: true);
            Console.ReadKey();
        }

        static void PrintDocument(string fileName, int noOfCopies=1, bool useColor=false)
        {
            Console.WriteLine("Printing {0} copies of {1} with color {2}", noOfCopies, fileName, useColor);
        }
    }
}
