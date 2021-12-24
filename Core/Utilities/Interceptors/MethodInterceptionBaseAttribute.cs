using Castle.DynamicProxy;
using System;


namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }// sıralama yapmak istersek örneğin;önce loglama gibi

        public virtual void Intercept(IInvocation invocation)
        {
            // Bunların içini dolduracağız
        }
    }
}
