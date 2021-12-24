using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            // Hangi nesne için validator yazacaksan buranın içine yazıyoruz
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            // örneğin içecek ise birim fiyatı 10dan büyük olmalı
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1); 
            // örneğin olmayan bir şeyi de kendimiz yazabiliriz
            // Ozel bir mesaj vermek istersek withmessagekullanırız
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı");// StartWithA bizim metodumuz
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
