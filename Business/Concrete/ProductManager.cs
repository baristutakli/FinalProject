using Business.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;
using Core.Utilities.Results;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        // Soyut nesne ile erişim sağlayacağız
        // Bu katmanda asla ınmemory veya entites direk çağırma
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {

            // ürünü eklemeden önce kontrol edeceğimiz kuralları buraya yazarız
            _productDal.Add(product);
            return new Result(true, "Ürün eklendi");
        }

        public List<Product> getAll()
        {
            // iş kodları varsa bunları yazıyoruz
            // bir iş sınıfı başka sınıfları dinlemesin
            // İş kolları
            // Yetkisi var mı?
            return _productDal.GetAll();
        }

  
        public List<Product> getAllByCategory(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public Product getById(int productId)
        {
            return _productDal.Get(p => p.ProductId == productId);
        }

        public List<Product> getByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> getProductDetail()
        {
           return _productDal.getProductDetail();
        }
    }
}
