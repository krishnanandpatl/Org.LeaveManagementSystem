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
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
        }
    }
}