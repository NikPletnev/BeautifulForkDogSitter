﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.BLL.Exeptions
{
    public class WorkTimeBusyException : Exception
    {
        public WorkTimeBusyException(string message) : base(message)
        {

        }

    }
}
