using AutoMapper;
using MediatR;
using Org.LeaveManagementSystem.Application.DTOs.LeaveAllocation.Validators;
using Org.LeaveManagementSystem.Application.Features.LeaveAllocations.Requests.Commands;
using Org.LeaveManagementSystem.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Org.LeaveManagementSystem.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly Mapper _mapper;

        public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository,ILeaveTypeRepository leaveTypeRepository,Mapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveAllocationDtoValidator(_leaveTypeRepository);
            var validatedResult = await validator.ValidateAsync(request.UpdateLeaveAllocationDto);
            if (validatedResult.IsValid == false)
            {
                throw new Exception();
            }

            var leaveAllocation =await _leaveAllocationRepository.Get(request.UpdateLeaveAllocationDto.Id);

            _mapper.Map(request.UpdateLeaveAllocationDto,leaveAllocation);

            await _leaveAllocationRepository.Update(leaveAllocation);

            return Unit.Value;
        }
    }
}
