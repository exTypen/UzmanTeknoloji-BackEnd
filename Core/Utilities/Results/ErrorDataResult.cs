using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        //Her çağrıldığında success bilgisi vermek zorunda olmayalım Error ve Success diye iki farklı class oluşturdum
        //Data döndürenler ve döndürmeyenler var.
        //Error ve success olanlar da base classı(Data ise dataResult değilse result) extend ediyor.
        //Classı parametre olarak sadece data'sını verirsek base classına hem datayı hem de false bilgisini döndürüyor
        //Data ile birlikte mesajı verirsek bu sefer yularıdakilerin yanına mesajı da katıyor.
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }

        public ErrorDataResult(T data) : base(data, false)
        {

        }

        public ErrorDataResult(string message) : base(default, false, message)
        {

        }

        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
