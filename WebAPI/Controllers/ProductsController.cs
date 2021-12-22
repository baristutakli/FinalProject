using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]// insanların istek yaparken nasıl ulaşacağını tanımlıyoruz
    [ApiController]// Bu sınıf bir controller dır ona göre tanımlandır
    public class ProductsController : ControllerBase
    {
        // Losely coupled
        // Soyuta bağlayarak ilerde manager ı değiştirdiğimizde bağımlı kalmayız ve sorun yaşamayız.
        //Ioc container yapısına ihtiyacımız var. Sebebi ise biz constructor içinde new productmanger yaparsam bağımlı olurum
        // Bağımlılığı azaltıyoruz
        // Ioc: Inversion of control
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // çağırırken /product/getall şeklinde çağıracağız
        // isim veriyoruz
        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            // Dependency chain var
            // Iproducservice product manager a o da efproductdal a bağlı
            //IProductService productService = new ProductManager(new EfProductDal());
            var result = _productService.getAll();
            if (result.Success)
            {
                return Ok(result);// 200 döndürür, overload'ı da var. Veri de verebiliriz
            }
            return BadRequest(result.Message);// 400 ve mesajın kendisini gönderdik. İsteseydik mesaj da göndermeyebilirdik.
        }


        // Post requestlerde  data göndereceğin için
        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.getById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
