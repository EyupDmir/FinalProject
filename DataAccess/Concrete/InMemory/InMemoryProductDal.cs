using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products; //ctor tab tab = constructor
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{ProductId =1,ProductName="Bardak",CategoryId=1, UnitPrice=15, UnitsInStock=15},
                new Product{ProductId =2,ProductName="Kamera",CategoryId=1, UnitPrice=500, UnitsInStock=3},
                new Product{ProductId =3,ProductName="Telefon",CategoryId=2, UnitPrice=1500, UnitsInStock=2},
                new Product{ProductId =4,ProductName="Klavye",CategoryId=2, UnitPrice=150, UnitsInStock=65},
                new Product{ProductId =5,ProductName="Fare",CategoryId=2, UnitPrice=85, UnitsInStock=1},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);  // Listeye product ekleme
        }

        public void Delete(Product product)
        {
            //" _products.Remove(product); " //Bu kod normalde bir listeden eleman silmeye yarar. Ama burda bu şekilde çalışmaz!!! 
            //Sebebi ise yukarıdaki elemanlarda süslü parantezler kullanılmıştır
            //Ürünleri silerken onun primary keyini kullanırız. 

            //LİNQ - Language Integrated Qoery
            Product productToDelete = _products.SingleOrDefault(product => product.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products; 
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList(); 
            //Where koşulu içindeki şarta uygun tüm elemanları yeni bir liste haline getirip onu döndürür.
        }

        public List<ProductDetailDto> GetProductDetailDtos()
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductId = product.ProductId;
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
