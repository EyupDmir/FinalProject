using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //class   = referans tip olabilir demektir.
    //IEntity = IEntity olabilir veya IEntity implemente eden bir nesne olabilir
    //new()   = new'lenebilir olmalı
    public interface IEntityRepository<T> where T:class, IEntity, new()
    {
        //generic constraint = generici sınırlandırmak
        List<T> GetAll(Expression<Func<T,bool>> filter = null); //Kod sayesinde filtreleme yapabiliriz
        //E ticaret sitesindeki filtrelemeler gibi filtreleme yapmamızı sağlayacak
        T Get(Expression<Func<T,bool>> filter); //T döndüren get operasyonu
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
