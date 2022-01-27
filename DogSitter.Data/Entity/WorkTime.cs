using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.DAL.Entity
{
    internal class WorkTime
    {
        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateClouse { get; set; }
        public Weekdays Weekdays { get; set; }
    }
}
