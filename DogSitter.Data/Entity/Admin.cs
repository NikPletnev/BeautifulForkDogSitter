using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.DAL.Entity
{
    public class Admin
    {
        public int Id { get; set; }
        public string? /*Login?*/ Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string /*Email*/ Email { get; set; }
        public string /*Phone*/ Phone { get; set; }
        public bool IsDeleted { get; set; }

    }
}
