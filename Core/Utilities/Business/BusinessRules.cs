using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        //Manager'lar içinde kontrol methodları yazılıyor(Email kayıtlı mı kontrol etme gibi). Bu methodları tek bir method ile çalıştırıyoruz. Parametle olarak methodları veriyoruz.
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }

            return null;
        }


    }
}
