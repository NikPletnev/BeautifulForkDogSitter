using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.BLL.Models
{
    public class CustomerModel: UserModel
    {
        public  List<DogModel> Dogs { get; set; }
        public List<SitteModelr> Sitter { get; set; }
        public List<AddressModel> Address { get; set; }
        public List<OrderModel> Orders { get; set; }
    }
}
