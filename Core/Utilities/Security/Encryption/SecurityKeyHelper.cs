using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    //appsettings'de bulunan ssuperkey'i byte[] formatına çevirmek için kullanıyoruz. 
    //string ile key oluşturulamadığı için.
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            //Symmetric ve asymmetric'in farkını tam olarak bilmiyorum. Hoca anlatmamıştı konumuz değil diye.
            //Ben internetten bakmıştım fark olarak symmetric'te encrypt ve decrypt için tek key kullanılırken,
            //asymmetric'te encrypt için başka key decrypt için başka key kullanılıyormuş. 
            //Birde symmetric encryption asymmetric'e göre daha hızlı oluyormuş. 
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
