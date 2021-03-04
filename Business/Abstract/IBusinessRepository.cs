using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBusinessRepository<T> where T : class, new()
    {
        List<T> GetAll();
        void Add(T business);
        void Delete(T business);
        void Update(T business);
        T GetById(int id);


    }
}
