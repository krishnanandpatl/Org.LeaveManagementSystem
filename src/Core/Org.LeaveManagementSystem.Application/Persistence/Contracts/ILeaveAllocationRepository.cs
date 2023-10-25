using Org.LeaveManageSystem.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Org.LeaveManagementSystem.Application.Persistence.Contracts
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
        Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails();

    }
}