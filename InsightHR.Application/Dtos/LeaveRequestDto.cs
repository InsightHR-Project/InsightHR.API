using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Application.Dtos
{
    public class LeaveRequestDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } = "Pending";
        public string? ManagerComment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }

    public class LeaveRequestCreateDto
    {
        public int UserId { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Status { get; set; } = "Pending";
        public string? ManagerComment { get; set; }
    }

    public class LeaveRequestUpdateDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public string? ManagerComment { get; set; }
    }

    public class ManagerDecisionDto
    {
        public int Id { get; set; }
        public string Status { get; set; }  // "Approved" or "Rejected"
        public string? ManagerComment { get; set; }
    }
}
