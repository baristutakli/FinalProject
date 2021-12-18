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
using Business.Constants;

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
            // Business code
            // ürünü eklemeden önce kontrol edeceğimiz kuralları buraya yazarız
            // static oluşturduğumuz messages dosyasından direk yenilemeden kullanabiliriz
            // stringleri aşağıdaki gibi ayrı yarı yazmaya magic string denir.
            if (product.ProductName.Length<2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> getAll()
        {
            // iş kodları varsa bunları yazıyoruz
            // bir iş sınıfı başka sınıfları dinlemesin
            // İş kolları
            // Yetkisi var mı?
            return new DataResult<List<Product>( _productDal.GetAll(),true,"Ürünler listelendi");
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
