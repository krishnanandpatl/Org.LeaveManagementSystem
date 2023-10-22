using Org.LeaveManageSystem.Domain.Common;

namespace Org.LeaveManageSystem.Domain
{
    public class LeaveType : BaseDomainEntity
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}