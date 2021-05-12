
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.ValidationRules.FluentValidation
{
    //class'daki field'ların hangi özelliklere sahip olması gerektiğini belirliyoruz. İş methoduna attribute olarak eklenip kontrolünü sağlıyoruz.
    class ProductValidator : AbstractValidator<Product>
    {
       public ProductValidator()
       {
           RuleFor(product => product.Name).NotEmpty();
           
       }
    }
}
