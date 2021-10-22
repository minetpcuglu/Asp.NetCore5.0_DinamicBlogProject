using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
   public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Başlık boş geçilemez");
            RuleFor(x => x.BlogTitle).MinimumLength(3).MaximumLength(150).WithMessage("Geçerli başlık giriniz min 4 , max 150 karakter içermeli ");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("İçerik boş geçilemez");
        
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Görsel yolu boş geçilemez.");
        }
    }
}
