﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Org.LeaveManagementSystem.Application.DTOs.LeaveType
{
    public class CreateLeaveTypeDto : ILeaveTypeDto
    {
        public int DefaultDays { get; set; }
        public string Name { get; set; }
    }

}
