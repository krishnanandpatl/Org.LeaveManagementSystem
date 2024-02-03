using AutoMapper;
using MediatR;
using Org.LeaveManagementSystem.Application.DTOs.LeaveAllocation.Validators;
using Org.LeaveManagementSystem.Application.Exceptions;
using Org.LeaveManagementSystem.Application.Features.LeaveAllocations.Requests.Commands;
using Org.LeaveManagementSystem.Application.Persistence.Contracts;
using Org.LeaveManageSystem.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Org.LeaveManagementSystem.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly Mapper _mapper;

        public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository,ILeaveTypeRepository leaveTypeRepository,Mapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveAllocationDtoValidator(_leaveTypeRepository);
            var validatedResult = await validator.ValidateAsync(request.CreateLeaveAllocationDto);
            if (validatedResult.IsValid == false)
            {
                throw new ValidationException(validatedResult);
            }

            var leaveAllocation = _mapper.Map<LeaveAllocation>(request.CreateLeaveAllocationDto);
            leaveAllocation = await _leaveAllocationRepository.Add(leaveAllocation);
            return leaveAllocation.Id;
        }
    }
}
