using DevFramework.Northwind.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p=>p.CategoryId).NotEmpty().WithMessage("Kategori ID si girilmedi");
            RuleFor(p=>p.ProductName).NotEmpty().WithMessage("Ürün Adı boş olamaz");
            RuleFor(p=>p.UnitPrice).GreaterThan(5).WithMessage("Fiyat 0 dan büyük olmalı");
            RuleFor(p=>p.QuantityPerUnit).NotEmpty().WithMessage("Fiyat 0 dan büyük olmalı");
            RuleFor(p => p.ProductName).Length(2, 100);
            //RuleFor(p => p.ProductName).Must(StartWithA);


            
        }
        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");

        }
    }
}
