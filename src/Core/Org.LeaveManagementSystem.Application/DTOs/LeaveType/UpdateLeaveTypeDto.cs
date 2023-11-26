using Org.LeaveManagementSystem.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Org.LeaveManagementSystem.Application.DTOs.LeaveType
{
    public class UpdateLeaveTypeDto : BaseDto
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
