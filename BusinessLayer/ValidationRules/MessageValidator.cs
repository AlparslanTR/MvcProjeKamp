using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.MessageSenderMail).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
            RuleFor(x => x.MessageReceiverMail).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
            RuleFor(x => x.MessageSubject).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
            RuleFor(x => x.MessageSenderMail).MinimumLength(3).WithMessage("En Az 3 Karakter Girmelisiniz");
            
        }
    }
}
