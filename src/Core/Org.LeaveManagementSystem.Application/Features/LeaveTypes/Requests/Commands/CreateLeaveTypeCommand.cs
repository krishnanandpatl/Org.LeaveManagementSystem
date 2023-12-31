﻿using MediatR;
using Org.LeaveManagementSystem.Application.DTOs.LeaveType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Org.LeaveManagementSystem.Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateLeaveTypeCommand : IRequest<int>
    {
        public CreateLeaveTypeDto CreateLeaveTypeDto { get; set; }
    }
}
