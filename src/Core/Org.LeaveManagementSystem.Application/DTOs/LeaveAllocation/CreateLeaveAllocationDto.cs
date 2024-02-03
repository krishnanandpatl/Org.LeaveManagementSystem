using Org.LeaveManagementSystem.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Org.LeaveManagementSystem.Application.DTOs.LeaveAllocation
{
    public class CreateLeaveAllocationDto : ILeaveAllocationDto
    {
        public int Period { get; set; }
        public int LeaveTypeId { get; set; }
        public int NumberOfDays { get; set; }
    }
}
