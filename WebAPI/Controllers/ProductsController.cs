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
        [HttpGet]
        public string Get()
        {
            return "Merhaba";
        }
    }
}
