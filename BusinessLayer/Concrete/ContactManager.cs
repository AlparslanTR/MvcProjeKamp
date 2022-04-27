using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDal _contactdal;

        public ContactManager(IContactDal contactdal)
        {
            _contactdal = contactdal;
        }

        public void AboutAdd(Contact contact)
        {
            _contactdal.Insert(contact);
        }

        public void AboutDelete(Contact contact)
        {
            _contactdal.Delete(contact);
        }

        public void AboutUpdate(Contact contact)
        {
            _contactdal.Update(contact);
        }

        public Contact Get(int id)
        {
            return _contactdal.Get(x=>x.ContactId == id);
        }

        public List<Contact> GetList()
        {
            return _contactdal.list();
        }
    }
}
