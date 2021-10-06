using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            RuleFor(x => x.WriterPassword).Must(IsPasswordValidRules).WithMessage("Parolanızda en az bir küçük harf bir büyük harf ve rakamdan oluşmalıdır.");

        }
        private bool IsPasswordValidRules(string arg)
        {
            try
            {
                Regex writerPassword = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[0-9])[A-Za-z\d]");
                return writerPassword.IsMatch(arg);
            }
            catch
            {
                return false;
            }
        }
    }
}
