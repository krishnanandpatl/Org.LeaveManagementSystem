﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.LeaveManagementSystem.Application.Exceptions
{
    public class BadRequestException : ApplicationException
    {
        public BadRequestException(string message):base(message)
        {
            
        }
    }
}
