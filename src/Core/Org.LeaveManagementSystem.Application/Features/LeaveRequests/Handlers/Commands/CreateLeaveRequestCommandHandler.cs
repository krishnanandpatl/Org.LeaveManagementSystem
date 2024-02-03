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
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly Mapper _mapper;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository,ILeaveTypeRepository leaveTypeRepository,Mapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.CreateLeaveRequestDto);
            if(validationResult.IsValid==false)
            {
                throw new Exception();
            }

            var leaveRequest = _mapper.Map<LeaveRequest>(request.CreateLeaveRequestDto);
            leaveRequest=await _leaveRequestRepository.Add(leaveRequest);
            return leaveRequest.Id;
        }
    }
}
