using AutoMapper;
using MediatR;
using Org.LeaveManagementSystem.Application.DTOs.LeaveRequest.Validators;
using Org.LeaveManagementSystem.Application.Features.LeaveRequests.Requests.Commands;
using Org.LeaveManagementSystem.Application.Persistence.Contracts;
using Org.LeaveManageSystem.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Org.LeaveManagementSystem.Application.Features.LeaveRequests.Handlers.Commands
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand,Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly Mapper _mapper;

        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository,ILeaveTypeRepository leaveTypeRepository,Mapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveRquestDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateLeaveRequestDto);
            if (validationResult.IsValid == false)
            {
                throw new Exception();
            }

            var leaveRequest = await _leaveRequestRepository.Get(request.Id);

            if (request.UpdateLeaveRequestDto != null)
            {
                
                _mapper.Map(request.UpdateLeaveRequestDto, leaveRequest);

                await _leaveRequestRepository.Update(leaveRequest);

            }
            else if(request.ChangeLeaveRequestApprovalDto != null) 
            {
                await _leaveRequestRepository.ChangeApprovalStatus(leaveRequest, request.ChangeLeaveRequestApprovalDto.Approved);
            }

            return Unit.Value;
        }
    }
}
