using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatihanDapper.Repository
{
    internal interface IRepositoryBase<T> { 
    IEnumerable<T> FindAll();
    IEnumerable<T> FindById(dynamic id);
    T Save(T Entity);
    T Update(T Entity);
    void Delete(T Entity);
    }
}
