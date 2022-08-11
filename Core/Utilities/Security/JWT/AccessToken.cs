using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken //AccessToken = anlamsız karakterlerden oluşan bir anahtar değeridir. Buyüzden string olarak tutulur.
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        

    }
}
//Token JWT değerimizin kendisi. Kullanıcı API (postman) üzerinden bize kullanıcı adı ve parolasını vericek bizede ona bir token vereceğiz. Sonrada token'nın ne zaman sonlanacağını belirleyeceğiz.