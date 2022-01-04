using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        // iş katmanında kullanacağımız servis 
        // işlem sonucunun dışında mesaj ve durumu gönderiyoruz
        IDataResult<List<Product>> getAll();
        IDataResult<Product> getById(int productId);
        IDataResult<List<Product>> getAllByCategory(int id);
        IDataResult<List<Product>> getByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> getProductDetail();
        IResult Add(Product product);
        IResult Update(Product product);

        /// <summary>
        /// Uygulamalarda tutarlılığı korumak için kullandığımız bir yöntem. Örneğin, bir hesaptan başka bir hesaba para gönderme
        /// Eğer bu işlem sırasında bir hata olursa paranın geri alınmasını sağlayan yöntem
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        IResult AddTransactionTest(Product product);

    }
}
