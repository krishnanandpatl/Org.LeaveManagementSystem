using AutoMapper;
using Org.LeaveManagementSystem.Application.DTOs.LeaveAllocation;
using Org.LeaveManagementSystem.Application.DTOs.LeaveRequest;
using Org.LeaveManagementSystem.Application.DTOs.LeaveType;
using Org.LeaveManageSystem.Domain;

namespace Org.LeaveManagementSystem.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region LeaveRequest
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
            CreateMap<LeaveRequest, CreateLeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, UpdateLeaveRequestDto>().ReverseMap();
            #endregion
            #region Leave Type
            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<LeaveType, CreateLeaveTypeDto>().ReverseMap();
            #endregion
            #region Leave Allocation
            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocation, CreateLeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocation, UpdateLeaveAllocationDto>().ReverseMap();
            #endregion
        }
    }
}