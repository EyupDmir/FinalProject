using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //This = constructğor'ın kendisini gösterir
        //:this(success) = bu constructor'un success parametresini gönder
        public Result(bool success, string message):this(success) 
        {
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }

    }
}
