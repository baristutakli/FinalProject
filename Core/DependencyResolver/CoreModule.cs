using Core.CorssCuttingConcerns.Caching;
using Core.CorssCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DependencyResolver
{
    public class CoreModule : ICoreModule
    {
        /// <summary>
        /// Iugulama seviyesinde servis bağımlılıklarımızı çözümleyeceğimiz yer
        /// </summary>
        /// <param name="serviceCollection"></param>
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();// memory cahche karşılığı
            // redis e geçersen yapacağın hareket sadece momort yerine redis yazmak
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            serviceCollection.AddSingleton<Stopwatch>();
        }
    }
}
