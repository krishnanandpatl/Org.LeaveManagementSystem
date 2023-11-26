using MediatR;
using Org.LeaveManagementSystem.Application.DTOs.LeaveRequest;
using System;
using System.Collections.Generic;
using System.Text;

namespace Org.LeaveManagementSystem.Application.Features.LeaveRequests.Requests.Commands
{
    public class UpdateLeaveRequestCommand : IRequest<Unit>
    {
        public UpdateLeaveRequestDto UpdateLeaveRequestDto { get; set; }
    }
}
