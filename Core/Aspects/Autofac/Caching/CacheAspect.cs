using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using Core.CrossCuttingConcern.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60) //kalacağı süre default 60dk
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            //methodname = namespace ismi.class ismi
            //arguments method içerisindeki parametreleri listeler. Yoksa null
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            if (_cacheManager.IsAdd(key)) //cache'de var mı?
            {
                invocation.ReturnValue = _cacheManager.Get(key); //return değeri cache'deki data olsun demek -> ReturnValue
                return;
            }
            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration); //returnValue ile cache ekleme yapar
        }
    }
}
