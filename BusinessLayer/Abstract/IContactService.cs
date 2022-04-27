using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetList();
        void AboutAdd(Contact contact);
        Contact Get(int id);
        void AboutDelete(Contact contact);
        void AboutUpdate(Contact contact);
    }
}
