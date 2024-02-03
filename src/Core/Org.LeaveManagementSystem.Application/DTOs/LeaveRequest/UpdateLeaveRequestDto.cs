using Org.LeaveManagementSystem.Application.DTOs.Common;
using Org.LeaveManagementSystem.Application.DTOs.LeaveType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Org.LeaveManagementSystem.Application.DTOs.LeaveRequest
{
    public class UpdateLeaveRequestDto : BaseDto,ILeaveRequestDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveTypeId { get; set; }
        public string RequestComments { get; set; }
        public bool Cancelled { get; set; }
    }
}
