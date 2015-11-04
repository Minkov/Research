using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> All();

        T Find(int id);

        void Add(T entity);

        IQueryable<T> Search(Expression<Func<T, bool>> filter);
    }
}
