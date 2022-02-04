using System;
using ProductsLibrary;
namespace ProductsLibraryClient
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = -1;
            IProductRepository repo = new ProductRepository();
            CommandsInvoker invoker = new CommandsInvoker();
            do
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(" 1.  Add product");
                Console.WriteLine(" 2.  Remove product");
                Console.WriteLine(" 3.  Display products");
                Console.WriteLine(" 4.  Undo");
                Console.WriteLine("-1.  Exit");
                Console.WriteLine();
                Console.WriteLine("Enter your choice");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter id and name");
                        var product = new Product();
                        product.Id = int.Parse(Console.ReadLine());
                        product.Name = Console.ReadLine();

                        var addCommand = new AddProductCommand(product, repo);
                        invoker.Invoke(addCommand);

                        break;
                    case 2:
                        Console.WriteLine("Enter id");
                        int id = int.Parse(Console.ReadLine());

                        var deleteCommand = new DeleteProductCommand(id, repo);
                        invoker.Invoke(deleteCommand);

                        break;

                    case 3:
                        Console.WriteLine("Id\t\tName");
                        foreach (var item in repo.GetAll())
                        {
                            Console.WriteLine("{0}\t\t{1}", item.Id, item.Name);
                        }
                        break;
                    case 4:
                        invoker.Undo();
                        break;
                }


            } while (choice != -1);
        }
    }
}
