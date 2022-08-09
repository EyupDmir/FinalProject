using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity); //Product tipinde product için doğrulama yapacağımızı belirtiyoruz.
            var result =validator.Validate(context);
            if (!result.IsValid) //Sonuç Geçerli değil ise 
            {
                throw new ValidationException(result.Errors); //Hata fırlat
            }
        }
    }
}
