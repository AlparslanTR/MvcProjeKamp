using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public interface IAboutManager
    {
        void AboutAdd(About about);
        void AboutDelete(About about);
        void AboutUpdate(About about);
        About Get(int id);
        List<About> GetList();
    }
}