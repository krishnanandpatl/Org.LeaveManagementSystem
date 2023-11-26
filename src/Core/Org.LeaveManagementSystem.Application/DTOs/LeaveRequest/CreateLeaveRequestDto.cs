using Org.LeaveManagementSystem.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Org.LeaveManagementSystem.Application.DTOs.LeaveRequest
{
    public class CreateLeaveRequestDto
    {
        public string RequestComments { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
    }
}
