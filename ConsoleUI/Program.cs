using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    //SOLID
    //O = Open Closed Principle
    //Programa yeni bir özellik ekliyorsan mevcuttaki hiçbir koduna dokunamazsın
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetAll())
                //Artık GetAll demek yerine istediğimiz özelliği yazabiliriz. GetAllByCategoryIs(2) gibi
            {
                Console.WriteLine(product.ProductName);
            }


        }
    }
}
 