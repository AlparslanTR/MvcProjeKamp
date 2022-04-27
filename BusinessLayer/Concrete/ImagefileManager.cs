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
    public class ImagefileManager : IImagefileService
    {
         IImageFileDal _ımagedal;

        public ImagefileManager(IImageFileDal ımagedal)
        {
            _ımagedal = ımagedal;
        }

        public ImageFile Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<ImageFile> GetList()
        {
            return _ımagedal.list();
        }

        public List<ImageFile> GetListByID(int id)
        {
            throw new NotImplementedException();
        }

        public void ImageAdd(ImageFile ımageFile)
        {
            throw new NotImplementedException();
        }

        public void ImageRemove(ImageFile ımageFile)
        {
            throw new NotImplementedException();
        }

        public void ImageUpdate(ImageFile ımageFile)
        {
            throw new NotImplementedException();
        }
    }
}
