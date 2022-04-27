using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IImagefileService
    {
        List<ImageFile> GetList();
        List<ImageFile> GetListByID(int id);
        void ImageAdd(ImageFile ımageFile);
        void ImageRemove(ImageFile ımageFile);
        void ImageUpdate(ImageFile ımageFile);
        ImageFile Get(int id);
    }
}
