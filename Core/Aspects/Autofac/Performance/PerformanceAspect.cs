using System.Diagnostics;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Performance
{
    //
    public class PerformanceAspect : MethodInterception
    {
        private int _interval;
        //timer
        private Stopwatch _stopwatch;

        public PerformanceAspect(int interval)
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }


        protected override void OnBefore(IInvocation invocation)
        {
            //kronometre başlat
            _stopwatch.Start();
        }

        protected override void OnAfter(IInvocation invocation)
        {
            //geçen süre verilen büyük olursa uyarır.
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
            {
                Debug.WriteLine(
                    //Dubug'a method ismi ile yazar. Sorun neyde olduğunu anlarız
                    $"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}");
            }

            _stopwatch.Reset();
        }
    }
}