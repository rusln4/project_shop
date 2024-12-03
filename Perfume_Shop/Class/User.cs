using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfume_Shop.Class
{
    public class User
    {
        public string Id { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Otchestvo { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Check { get; set; } = 1;
        public DateTime LockTime { get; set; }


        public User()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
