using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    //Login-Register işlemlerinde token döndürüyoruz. Token kullanıcı bilgileri, roller gibi bilgileri içeriyor. 
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
