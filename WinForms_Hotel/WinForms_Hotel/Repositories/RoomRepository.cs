using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForms_Hotel.Classes;

namespace WinForms_Hotel.Repositories
{
    class RoomRepository : GenericRepository<Room>
    {
        public Room GetByTypeOfRoom(string name)
        {
            return _entities.FirstOrDefault(r => r.TypeOfRoom.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public List<Room> GetAllSortedByPrice()
        {
            return _entities.OrderBy(r => r.Price).ToList();
        }
    }
}
