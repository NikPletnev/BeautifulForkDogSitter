using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.BLL.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public bool IsDeleted { get; set; }
        public ContactTypeModel ContactType { get; set; }
    }
}
