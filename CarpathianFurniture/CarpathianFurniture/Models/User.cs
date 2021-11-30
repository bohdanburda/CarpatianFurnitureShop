using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpathianFurniture.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public int? RoleId { get; set; }
        public List<Furniture> ShoppingCart { get; set; }
        public Role Role { get; set; }
        public User()
        {
            ShoppingCart = new List<Furniture>();
        }
    }
}
