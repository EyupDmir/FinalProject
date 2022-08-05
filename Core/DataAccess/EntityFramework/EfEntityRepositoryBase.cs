using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity> //Bu kodu bir daha kullanmayacaksın. Bir kez kullandıktan sonra 
        //Bir entity ve bir context tipi ver demektir.
        where TEntity: class, IEntity, new()
        where TContext: DbContext,new()
    {
        public void Add(TEntity entity)
        {
            //Normal şartlarda bir class newlendiğinde belli bir süre sonra garbage kolektör onu atar.
            //using fonksiyonu ise bittikten sonra direk garbage'a gidecek ve atılıcak.
            //Belleği hızlıca temizle
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity); //git veri kaynağından gönderdiğim producktan bir tanesini eşleştir.
                addedEntity.State = EntityState.Added; //Yapılacak işlemi seçme
                context.SaveChanges(); //Değişiklikleri kaydetme
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity); //git veri kaynağından gönderdiğim producktan bir tanesini eşleştir.
                deletedEntity.State = EntityState.Deleted; //Yapılacak işlemi seçme
                context.SaveChanges(); //Değişiklikleri kaydetme
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter); //Bizim yerimize tabloyu liste gibi ele alıp filtreliyor.
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList() //Product'ı listeye dönüştür.
                    : context.Set<TEntity>().Where(filter).ToList(); //Filtreleyip Listeye Dönüştür.
                //Filtre Null mı? Null ise birinci satır, değilse ikinci satır çalışır.
                //veritabanındaki product tablosunun tamamını ToList'e(Listeye) çevir.
                //üstteki üç satırı tek satır olarakta yazabiliriz.
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity); //git veri kaynağından gönderdiğim producktan bir tanesini eşleştir.
                updatedEntity.State = EntityState.Modified; //Yapılacak işlemi seçme
                context.SaveChanges(); //Değişiklikleri kaydetme
            }
        }
    }
}
