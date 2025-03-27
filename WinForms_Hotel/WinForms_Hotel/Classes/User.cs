using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForms_Hotel.Interfaces;

namespace WinForms_Hotel.Classes
{
    class User : BaseEntity, IUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Admin { get; set; }
        public User(string name, int id) : base(id)
        {
            Name = name;
        }
    }
}
