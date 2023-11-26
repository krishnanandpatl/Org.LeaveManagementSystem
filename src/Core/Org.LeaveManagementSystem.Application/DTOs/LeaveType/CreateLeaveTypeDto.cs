using System;
using System.Collections.Generic;
using System.Text;

namespace Org.LeaveManagementSystem.Application.DTOs.LeaveType
{
    public class CreateLeaveTypeDto
    {
        public int DeafaultDays { get; set; }
        public string Name { get; set; }
    }
}
