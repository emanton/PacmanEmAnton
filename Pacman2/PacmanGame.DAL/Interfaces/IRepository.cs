using System.Collections.Generic;

namespace PacmanGame.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Add(T item);
        /*void Update(T item);
        void Delete(int id);
        T Get(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);*/
    }
}