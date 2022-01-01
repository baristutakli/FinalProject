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
using FluentValidation;
using Business.ValidationRules.FluentValidation;
using Core.CorssCuttingConcerns.Validation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Business.BusinessAspects.Autofac;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        // Soyut nesne ile erişim sağlayacağız
        // Bu katmanda asla ınmemory veya entites direk çağırma
        IProductDal _productDal;
        ICategoryService _categoryService;// Productan bağımzı olduğu için sevice ekledik

        // Dikkat bir Entity Manager kendisi hariç başka bir varlığı Constructor'a  varlık eklenemez
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }
        // Yetkilendirmeyi JWT kullanarak yapacağız
        // Şimdilik yetki dediğimiz yapılara claim diyoruz
        // Herhangi bir token yoksa uygulamamız ona senin yetkin yok diyecektir
        // "product.add,editor" ekelem yetkisi olan  birine sahip olması gerekiyor
        [SecuredOperation("product.add,admin")] // Bu metodu çağıran kişinin yetkisini ayrı ayrı yapabiliriz
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            // Business code
            // Urünü eklemeden önce kontrol edeceğimiz kuralları buraya yazarız
            // static oluşturduğumuz messages dosyasından direk yenilemeden kullanabiliriz
            // Validation: bir nesneyi iş kurallarına dahil etmek için uygun olup olmadıgını kontrol ederiz
            // Örneğin;minimum kaç karakter olabilir vs nesnenin yapısı ile ilgili

            ////if (product.UnitPrice<=0)
            ////{
            ////    // buda validationdır
            ///w/    return new ErrorResult(Messages.UnıtNameInvalid);
            ////}
            //// iş kuralı ise bizim iş gereksinimlerimize uygunluk gösterir
            //// örn; bir kişiye ehliyet vereceksiniz ona uygun olup olmadığını kontrol ettiğimiz
            //// puanlarına bakmak vs 

            // Business codes
            IResult result = BusinessRules.Run(CheckIfProductExists(product.ProductName),
                CheckIfProductCountOfCategory(product.CategoryId));

            if (result!=null)
            {
                return result;
            }
            _productDal.Add(product);
            return new ErrorResult();
        }


        /*
         * Bir veriyi karşı taraf okuyamasın diye yapılan çalışmalardır
         *Encription: 
         *Hashing: veri tabanındaki parolayı açıkta tutabiliriz ama açık tutmak yerine onları hash leriz.
         *Örneğin;1234@1234 parolasını MD5, SHA1 gibi şifreleme algoritmaları vasıtasıyla geri dönüşü olmayacak şekilde hashlenirler.
         * Bunun sonucunda BDSDXc-sadsfas-asdas seklinde tutarız.
         * Kullanıcı bir mail ve şifre gidiğinde parolayı şifreledikten sonra onu hash liyoruz 
         * Eğer veri tabanında aynı hash  varsa izin veriyoruz. Hash karşılaştırması gerçekleştiriyoruz.
         * 
         * Bir kişinin girdiği değere kendimiz bir şeyler ekleyerek hash liyoruz
         * Bu şekilde kullanıcının girdiği parolayı biraz daha güçlendirmiş oluyoruz.
         * Encription: geri dönüşü olan veridir. Girdiğimiz dahayı encript ce decriypte edebiliriz.
         * Bunu yapabilmek için neyle ve nasıl çözdüğümüzü bilmemiz gerekir.
         * Key varsa o anahtarı 
         *
         */
        public IDataResult<List<Product>> getAll()
        {
            // iş kodları varsa bunları yazıyoruz
            // bir iş sınıfı başka sınıfları dinlemesin
            // İş kolları
            // Yetkisi var mı?

            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>( _productDal.GetAll(),Messages.ProductListed);
        }

  
        public IDataResult<List<Product>> getAllByCategory(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> getById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> getByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> getProductDetail()
        {
           return new SuccessDataResult<List<ProductDetailDto>>(_productDal.getProductDetail());
        }


        /// <summary>
        /// * Bu bir iş kuralı parçacığıdır. Bir kategoride en fazla kaç ürün var onu doğruluyoruz
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        private IResult CheckIfProductCountOfCategory(int CategoryID)
        {
            var result = _productDal.GetAll(p => p.CategoryId == CategoryID).Count;
            if (result>=15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);

            }
            return new SuccessResult();
        }
        private IResult CheckIfProductExists(String productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);

            }
            return new SuccessResult();
        }
    }
}
