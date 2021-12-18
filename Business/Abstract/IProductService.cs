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
        List<Product> getAll();
        List<Product> getAllByCategory(int id);
        List<Product> getByUnitPrice(decimal min, decimal max);
        List<ProductDetailDto> getProductDetail();
    }
}
