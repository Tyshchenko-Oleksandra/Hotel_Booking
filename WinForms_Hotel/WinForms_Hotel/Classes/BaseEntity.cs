using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_Hotel.Classes
{
    public abstract class BaseEntity
    {
        public int Id { get; }
        protected BaseEntity(int id)
        {
            Id = id;
        }
    }
}
