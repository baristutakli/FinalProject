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

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            // Business code
            // ürünü eklemeden önce kontrol edeceğimiz kuralları buraya yazarız
            // static oluşturduğumuz messages dosyasından direk yenilemeden kullanabiliriz
            // Validation: bir nesneyi iş kurallarına dahil etmek için uygun olup olmadıgını kontrol ederiz
            // örn;minimum kaç karakter olabilir vs nesnenin yapısı ile ilgili

            ////if (product.UnitPrice<=0)
            ////{
            ////    // buda validationdır
            ///w/    return new ErrorResult(Messages.UnıtNameInvalid);
            ////}
            //// iş kuralı ise bizim iş gereksinimlerimize uygunluk gösterir
            //// örn; bir kişiye ehliyet vereceksiniz ona uygun olup olmadığını kontrol ettiğimiz
            //// puanlarına bakmak vs 

            // Business codes
            BusinessRules.Run(CheckIfProductExists(product.ProductName),
                CheckIfProductCountOfCategory(product.CategoryId));
           


            return new ErrorResult();
        }

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
