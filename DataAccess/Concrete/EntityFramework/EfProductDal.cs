using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        //NuGet
        //operasyonlar
        public void Add(Product entity)
        {
            //Normal şartlarda bir class newlendiğinde belli bir süre sonra garbage kolektör onu atar.
            //using fonksiyonu ise bittikten sonra direk garbage'a gidecek ve atılıcak.
            //Belleği hızlıca temizle
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity); //git veri kaynağından gönderdiğim producktan bir tanesini eşleştir.
                addedEntity.State = EntityState.Added; //Yapılacak işlemi seçme
                context.SaveChanges(); //Değişiklikleri kaydetme
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity); //git veri kaynağından gönderdiğim producktan bir tanesini eşleştir.
                deletedEntity.State = EntityState.Deleted; //Yapılacak işlemi seçme
                context.SaveChanges(); //Değişiklikleri kaydetme
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter); //Bizim yerimize tabloyu liste gibi ele alıp filtreliyor.
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using(NorthwindContext context = new NorthwindContext())
            {
                return filter == null 
                    ? context.Set<Product>().ToList() //Product'ı listeye dönüştür.
                    : context.Set<Product>().Where(filter).ToList(); //Filtreleyip Listeye Dönüştür.
                //Filtre Null mı? Null ise birinci satır, değilse ikinci satır çalışır.
                //veritabanındaki product tablosunun tamamını ToList'e(Listeye) çevir.
                //üstteki üç satırı tek satır olarakta yazabiliriz.
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity); //git veri kaynağından gönderdiğim producktan bir tanesini eşleştir.
                updatedEntity.State = EntityState.Modified; //Yapılacak işlemi seçme
                context.SaveChanges(); //Değişiklikleri kaydetme
            }
        }
    }
}
