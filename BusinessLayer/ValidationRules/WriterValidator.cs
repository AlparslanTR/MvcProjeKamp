using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
            RuleFor(x => x.WriterImage).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
            RuleFor(x => x.WriterPass).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("En Az 2 Karakter Girmelisiniz");
            RuleFor(x => x.WriterName).MaximumLength(20).WithMessage("En Fazla 20 Karakter Girmelisiniz");
            RuleFor(x => x.WriterSurName).MinimumLength(2).WithMessage("En Az 2 Karakter Girmelisiniz");
            RuleFor(x => x.WriterSurName).MaximumLength(20).WithMessage("En Fazla 20 Karakter Girmelisiniz");
            RuleFor(x => x.WriterAbout).MaximumLength(100).WithMessage("En Fazla 100 Karakter Girmelisiniz");
            RuleFor(x => x.WriterPass).MaximumLength(20).WithMessage("En Fazla 20 Karakter Girmelisiniz");
            RuleFor(x => x.WriterTitle).MaximumLength(25).WithMessage("En Fazla 25 Karakter Girmelisiniz");
        }
    }
}
