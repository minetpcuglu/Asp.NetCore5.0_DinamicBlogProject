using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
   public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı soyadı  boş geçilemez");
            RuleFor(x => x.WriterName).MinimumLength(3).MaximumLength(50).WithMessage("Geçerli bir ad soyad giriniz min 4 , max 50 olmalı ");
            RuleFor(x => x.WriterMail).NotEmpty().EmailAddress().WithMessage("Mail boş geçilemez");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş geçilemez");
         
        }
    }
}
