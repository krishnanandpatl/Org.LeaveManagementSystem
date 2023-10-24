using Org.LeaveManagementSystem.Application.DTOs.Common;
using Org.LeaveManagementSystem.Application.DTOs.LeaveType;
using Org.LeaveManageSystem.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Org.LeaveManagementSystem.Application.DTOs.LeaveAllocation
{
    public class LeaveAllocationDto : BaseDto
    {
        public int NumberOfDays { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}