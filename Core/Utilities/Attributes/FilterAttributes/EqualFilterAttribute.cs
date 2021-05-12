using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Attributes.FilterAttributes
{
    //Bunu açıkcası tam anladığım söylenemez. Birinden gördüm daha dün ekledim projeye. Gördüğüm projenin sahibinini müsait bir zamanını kovalıyorum anlatması için.
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class EqualFilterAttribute : FilterAttribute
    {
        public EqualFilterAttribute(string targetProperty) : base(targetProperty, "equal")
        {
        }
    }
}