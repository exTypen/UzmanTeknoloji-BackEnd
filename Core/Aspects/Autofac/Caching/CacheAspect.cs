using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            //Aspect olduğu injection yapamıyoruz yine serviceTool kullanıyoruz.
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            //                                     Classın namespacini aldık              Method'un ismini aldık
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            //Methodun parametresini listeye çevir.
            var arguments = invocation.Arguments.ToList();
            //Eğer paramtere varsa parantez içinde paramtreleri veriyoruz
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            //Bellekte böyle bir cache var mı ona bakıyoruz
            if (_cacheManager.IsAdd(key))
            {
                //methodu çalıştırmadan geri dön value'yide cache den çektik
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            //yoksa methodu devam ettir
            invocation.Proceed();
            //Metod bittikten sonra cache de olmadığı için cache ekledik.
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
