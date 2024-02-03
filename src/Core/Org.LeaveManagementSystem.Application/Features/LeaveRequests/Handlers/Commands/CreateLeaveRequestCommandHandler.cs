using AutoMapper;
using MediatR;
using Org.LeaveManagementSystem.Application.CustomResponses;
using Org.LeaveManagementSystem.Application.DTOs.LeaveRequest.Validators;
using Org.LeaveManagementSystem.Application.Exceptions;
using Org.LeaveManagementSystem.Application.Features.LeaveRequests.Requests.Commands;
using Org.LeaveManagementSystem.Application.Persistence.Contracts;
using Org.LeaveManageSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Org.LeaveManagementSystem.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
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
        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            BaseCommandResponse response = new BaseCommandResponse();
            var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.CreateLeaveRequestDto);
            if(validationResult.IsValid==false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors=validationResult.Errors.Select(q=>q.ErrorMessage).ToList();
                throw new ValidationException(validationResult);
            }

            var leaveRequest = _mapper.Map<LeaveRequest>(request.CreateLeaveRequestDto);
            leaveRequest=await _leaveRequestRepository.Add(leaveRequest);
            response.Id= leaveRequest.Id;
            response.Message = "Creation Successful";
            return response;
        }
    }
}
