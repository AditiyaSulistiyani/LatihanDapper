using LatihanDapper.DbContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatihanDapper.Repository
{
    internal abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly DapperDbContext _context;
        protected readonly AdoDbContext _adoDbContext;
        public RepositoryBase(DapperDbContext Context, AdoDbContext adoDbContext )
        {
           _context  = Context;
            _adoDbContext = adoDbContext;
        }
        public virtual void Delete(T Entity)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> FindAll()
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> FindById(dynamic id)
        {
            throw new NotImplementedException();
        }

        public virtual T Save(T Entity)
        {
            throw new NotImplementedException();
        }

        public virtual T Update(T Entity)
        {
            throw new NotImplementedException();
        }
    }
}
