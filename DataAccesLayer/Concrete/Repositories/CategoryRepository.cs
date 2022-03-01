using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Concrete.Repositories

    /*
     * ToList=Listeleme
     * Add=Ekleme
     * Remove=Kaldır
     * Find=Bul
     */
{
    public class CategoryRepository : ICategoryDal
    {
        Context c = new Context();
        DbSet<Category>_object;

        public void Delete(Category p)
        {
            _object.Remove(p);
            c.SaveChanges();
        }

        public void Insert(Category p)
        {
             _object.Add(p);
            c.SaveChanges();
        }

        public List<Category> list()
        {
            throw new NotImplementedException();
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Category> listele()
        {
           return _object.ToList();
        }

        public void Update(Category p)
        {
            c.SaveChanges();
        }
    }
}
