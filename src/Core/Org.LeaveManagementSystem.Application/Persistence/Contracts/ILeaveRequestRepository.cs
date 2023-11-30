using Org.LeaveManageSystem.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Org.LeaveManagementSystem.Application.Persistence.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
        Task<List<LeaveRequest>> GetLeaveRequestWithDetails();

        Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus );
    }
}