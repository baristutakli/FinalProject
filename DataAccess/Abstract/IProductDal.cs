
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    /// <summary>
    /// Irepository i product için yapılandırdım
    /// Defines the <see cref="IProductDal" />.
    /// </summary>
    public interface IProductDal:IEntityRepository<Product>
    {
        List<ProductDetailDto> getProductDetail();
    }
}
// Code Refactoring