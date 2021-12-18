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
    }
}
