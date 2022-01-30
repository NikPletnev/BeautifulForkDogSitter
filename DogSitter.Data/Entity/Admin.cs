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
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string /*Contact*/ Email { get; set; }
        public string /*Contact*/ Phone { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
