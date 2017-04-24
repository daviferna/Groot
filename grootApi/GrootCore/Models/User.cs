using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrootCore.Models
{
    public class User
    {
        public User() { }
        public int UserID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Groot Groot { get; set; }
        private Guid Password { get; set; }
    }
}
