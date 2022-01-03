﻿using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
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
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
