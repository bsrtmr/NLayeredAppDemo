using Northwind.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T:class,  IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null); //filter=null ile kullanıcı isterse filtre verecek ama vermese de olur demiş oluyoruz.
        T Get(Expression<Func<T, bool>> filter); //Burada kullanıcı bir filtre vermek zorunda çünkü sıralama bu şekilde olacak.
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
