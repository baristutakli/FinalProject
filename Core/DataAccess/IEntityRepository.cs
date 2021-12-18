using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    // generic constraint 
    // yazılan öğeyi kısıtlıyoruz
    //class: referans tip olabilir
    // T ya IEntity olabilir ya da ı entity den türetilen  bir nesne olabilir
    //
    public interface IEntityRepository<T> where T:class,IEntity,new()

    {
        /// <summary>
        /// GetAll yerine filtreleme işlemi yapabiliriz, bunu da Expression kullanabiliriz
        /// Buna Delege deniyor
        /// Bu metot ile category veya ürün için ayrı ayrı metot yazmamıza gerek kalmayacak
        /// </summary>
        /// <returns></returns>
        List<T> GetAll(Expression<Func<T,bool>> filter=null);

        /// <summary>
        /// Tek bir detayı getirmek için
        /// filtre verirse 
        /// </summary>
        /// <returns></returns>
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);


    }
}
