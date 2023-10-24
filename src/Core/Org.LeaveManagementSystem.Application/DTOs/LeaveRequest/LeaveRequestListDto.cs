using Org.LeaveManagementSystem.Application.DTOs.Common;
using Org.LeaveManagementSystem.Application.DTOs.LeaveType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Org.LeaveManagementSystem.Application.DTOs.LeaveRequest
{
    public class LeaveRequestListDto : BaseDto
    {
        public LeaveTypeDto LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
    }
}
