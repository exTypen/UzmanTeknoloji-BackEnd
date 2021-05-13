using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;
using Business.Constants;

namespace Business.BusinessAspects.Autofac
{
    //İş yapan methodlara attribute olarak eklenir. Parametre olarak methodun çalışması için gereken roller verilir. 
    //Parametre olarak verdiğimiz roller ile token'dan aldığı rolleri karşılaştırır. 
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            //aspecte inject yapamadığımız için serviceTool kullanıyoruz.
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        //Method'un önünde çalışacağını, çalışmadan önce yetki kontrolü yapacağımızı söylüyoruz.
        protected override void OnBefore(IInvocation invocation)
        {
            //Kullanıcının rollerini aldık.     
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            //parametre olarak verdiğimiz rolleri dönüyoruz. eğer kullanıcı rolleri paramtre olarak verdiğimiz rollerden birini içeriyorsa
            //method çalışıyor
            //yoksa hata veriyoruz
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
