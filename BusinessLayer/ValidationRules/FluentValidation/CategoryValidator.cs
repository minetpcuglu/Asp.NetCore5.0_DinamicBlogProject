using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
   public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adı boş geçilemez");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori açıklama boş geçilemez");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Kategori adı maks 50 karakter olmalı");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Kategori adı min 3 karakter olmalı");
        }
    }
}
