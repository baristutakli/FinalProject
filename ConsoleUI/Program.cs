using System;
using Business;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI {

    //SOLID 
    // Open closed principle
    class Program {
        static void Main(string[] args)
        {
            // Bana diyor ki hangi veri yöntemiyle çalıştığımı söylemen lazım diyor

            // DTO: Data transformation Object
            // Ioc

            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.getAll())
            {
                Console.WriteLine(product.ProductName);
            }
            Console.WriteLine("Hello World!");
        }
    }
}
