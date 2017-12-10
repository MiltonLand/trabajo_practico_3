using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    namespace DataAccess
    {
        //Propongo usar el repositorio que hizo Cesar en clase, o sea, el siguiente:
        //El resto del código de repositorios no lo entendí mucho, así que no sé si está bien o mal
        //este me parece más simple.

        public class Repository<T>
            where T : class
        {
            private DataModel _context;

            public Repository()
            {
                _context = new DataModel();
            }

            public T Persist(T entity)
            {
                return _context.Set<T>().Add(entity);
            }

            public void Remove(T entity)
            {
                _context.Set<T>().Remove(entity);
            }

            public T Update(T entity)
            {
                _context.Entry<T>(entity);

                return entity;
            }

            public IQueryable<T> Set()
            {
                return _context.Set<T>();
            }

            public void SaveChanges()
            {
                _context.SaveChanges();
            }
        }
    }

}
