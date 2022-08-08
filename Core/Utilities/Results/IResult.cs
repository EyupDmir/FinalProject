using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //Temel voidler için başlangıç
    public interface IResult
    {
        bool Success { get; } //Get = okunmak için 
        //işlemin doğru olup olmadığını kontrol etmek için
        string Message { get; }
        //doğru olup olmadığını kullanıcıya bildirmek için
    }
}
