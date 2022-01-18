using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamedParametersDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            PrintDocument("Toc.docx", 1);
            //PrintDocument(2, "Profile.pdf");
            PrintDocument(noOfCopies: 2, fileName: "Profile.pdf");
            Console.ReadKey();
        }

        static void PrintDocument(string fileName, int noOfCopies)
        {
            Console.WriteLine("Printing {0} copies of {1}", noOfCopies, fileName);
        }
    }
}
