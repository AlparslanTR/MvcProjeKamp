using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.ContactUserNameSurname).NotEmpty().WithMessage("Ad Soyad Boş Geçemezsiniz.");
            RuleFor(x => x.ContactUserMail).NotEmpty().WithMessage("Mail Adresi Boş Geçilemez.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Başlık Boş Geçemezsiniz.");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj Boş Geçemezsiniz.");
        }
    }
}
