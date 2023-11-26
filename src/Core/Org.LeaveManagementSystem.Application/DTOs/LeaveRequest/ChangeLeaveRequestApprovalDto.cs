using Org.LeaveManagementSystem.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Org.LeaveManagementSystem.Application.DTOs.LeaveRequest
{
    public class ChangeLeaveRequestApprovalDto : BaseDto
    {
        public bool? Approved { get; set; }
    }
}
