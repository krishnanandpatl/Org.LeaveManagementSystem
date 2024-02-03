using AutoMapper;
using MediatR;
using Org.LeaveManagementSystem.Application.DTOs.LeaveType.Validators;
using Org.LeaveManagementSystem.Application.Features.LeaveTypes.Requests.Commands;
using Org.LeaveManagementSystem.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Org.LeaveManagementSystem.Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly Mapper _mapper;

        public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository,Mapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveTypeDtoValidator();
            var validationResult =await validator.ValidateAsync(request.UpdateLeaveTypeDto);

            if (validationResult.IsValid)
            {
                throw new Exception();
            }

            var leaveType = await _leaveTypeRepository.Get(request.UpdateLeaveTypeDto.Id);

            _mapper.Map(request.UpdateLeaveTypeDto, leaveType);

            await _leaveTypeRepository.Update(leaveType);

            return Unit.Value;
        }
    }
}
