using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.BLL.Exeptions
{
    public class ServiceNotEnoughDataExeption : Exception
    {
        public ServiceNotEnoughDataExeption(string message) : base(message)
        {

        }

    }
}
