using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentApp.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
        IEnumerable<T> GetAll();
        T Get(long id);
        void Update(T entity);
        void Delete(T entity);
    }
}
