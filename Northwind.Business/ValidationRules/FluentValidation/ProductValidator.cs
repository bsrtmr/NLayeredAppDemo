using FluentValidation;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        //fluent validation
        //19 dilde mesaj olarak kullanıcıya uyarı yapabilir. Fakat WithMessage ile aşağıdaki gibi kendimiz de uyarı gönderebiliriz.
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün ismi boş olamaz!");
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.QuantityPerUnit).NotEmpty();
            RuleFor(p => p.UnitsInStock).NotEmpty();
            

            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitsInStock).GreaterThanOrEqualTo((short)0); //(short)'u integer dönüşümü için yazdık.
            RuleFor(p => p.UnitPrice).GreaterThan(10).When(p => p.CategoryId == 2); //p'nin CategoryId'si 2'ye eşit olduğunda UnitPrice'ı 10'dan büyük olmalı.

            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürün adı A ile başlamalı"); //Kendi kendimize de kural yazabiliriz.
        }

        private bool StartWithA(string arg) //True ya da False döner.
        {
            return arg.StartsWith("A");
        }
    }
}
