using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForms_Hotel.Classes;

namespace WinForms_Hotel.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected List<T> _entities = new List<T>();

        public List<T> GetAll()
        {
            return new List<T>(_entities); //ми повертаємо копію списку, для того щоб не було можливості змінити оригінальний список ззовні
        }

        public T GetById(int id)
        {
            return _entities.FirstOrDefault(e => e.Id == id);
        }

        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public void Remove(T entity)
        {
            _entities.Remove(entity);
        }
    }

    class HotelRepository<T> : GenericRepository<T> where T : Hotel
    {
        public T GetByName(string name)
        {
            return _entities.FirstOrDefault(h => h.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public List<T> GetAllSortedByName()
        {
            return _entities.OrderBy(h => h.Name).ToList();
        }

    }
}
