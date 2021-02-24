using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;

        }


        public List<Color> GetAll()
        {
           return _colorDal.GetAll();
        }

        public void Add(Color business)
        {
            _colorDal.Add(business);
        }

        public void Delete(Color business)
        {
            _colorDal.Delete(business);
        }

        public void Update(Color business)
        {
            _colorDal.Update(business);
        }

        public Color GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
