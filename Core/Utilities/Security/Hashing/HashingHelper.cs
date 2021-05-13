using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
   
    public class HashingHelper
    {
        //Şifreyi Database'de direkt o haliyle tutmak istemediğimizden yazılan şifreye önce saltlıyoruz. Daha sonra sha512 ile şifreliyoruz.
        //Hash ve Salt'ımızı da geri döndürüyoruz
        public static void CreatePasswordHash
            (string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                
                passwordSalt = hmac.Key;
                //ComputeHash bizden byte array istediği için string olan şifreyi encode ediyoruz.
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
               
            }
        }

        //verdiğimiz şifreyi hashliyoruz. Database'de ki hash ve salt(parametre olarak gönderiliyor) ile uyuşuyor mu kontrol ediyoruz.
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                //2 arrayin değerlerini karşılaştırıyoruz.
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]!=passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }

            
        }
    }
}
