using MediatR;
using Org.LeaveManagementSystem.Application.CustomResponses;
using Org.LeaveManagementSystem.Application.DTOs.LeaveRequest;
using System;
using System.Collections.Generic;
using System.Text;

namespace Org.LeaveManagementSystem.Application.Features.LeaveRequests.Requests.Commands
{
    public class CreateLeaveRequestCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveRequestDto CreateLeaveRequestDto { get; set; }
    }
}
