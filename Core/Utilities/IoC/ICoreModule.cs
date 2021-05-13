using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    //Her projede olacak resolve işlemlerini core katmanına taşımak için core'da da resolver class yazdık.
    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}
