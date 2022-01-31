using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.DAL.Entity
{
    public class Contact
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int ContactTypeId {get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual User User { get; set; }

    }
}
