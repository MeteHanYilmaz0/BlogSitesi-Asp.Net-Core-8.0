using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {

        public CategoryValidator() { 
         RuleFor(x=>x.CategoryName).NotEmpty().WithMessage("Kategori alanı boş bırakılamaz!");
         RuleFor(x=>x.CategoryDescription).NotEmpty().WithMessage("Kategori açıklaması alanı boş bırakılamaz!");
         RuleFor(x=>x.CategoryName).MinimumLength(2).WithMessage("Kategori alanı en az 2 karakter içermelidir!");
         RuleFor(x=>x.CategoryName).MaximumLength(50).WithMessage("Kategori alanı en fazla 50 karakter içermelidir!");
        }
    }
}
