using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty(); //Boş Olamaz (Zorunlu)
            RuleFor(p => p.ProductName).MinimumLength(2); //Min Uzunluk 2 Olmalı
            RuleFor(p => p.UnitPrice).NotEmpty(); //Boş Olamaz (Zorunlu)
            RuleFor(p => p.UnitPrice).GreaterThan(0); //0 dan Büyük Olmalı
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1); //10'a Eşit veya Daha Büyük Olmalı
            //Eğer yukarıdaki kod için bir hata mesajı vermek istiyorsak .WithMessage("...") yazarak çıkmasını istediğimiz mesajı belirtebiliriz. Aşağıda örneği var.
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalıdır."); //Must = Uymalı //Ürün İsmi A ile Başlamalı
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A"); //arg = stil fonksiyonu
        }
    }
}
