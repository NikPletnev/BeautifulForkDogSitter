using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.DAL.Entity
{
    public class Comment
    {
        public int Id { get; set; }
        public string Сommentary { get; set; }
        public DateTime Date { get; set; }
        public Order? Order { get; set; }
    }
}
