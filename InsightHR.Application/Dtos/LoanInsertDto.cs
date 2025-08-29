using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Application.Dtos
{
    public class LoanInsertDto
    {
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public string Reason { get; set; } = string.Empty;
        public int TenureMonths { get; set; }
        public string? SanctionLetterPath { get; set; }
        public int WagesId { get; set; }
        public DateTime FromDate { get; set; }
    }

    public class LoanResponseDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string RequestedBy { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Reason { get; set; } = string.Empty;
        public int TenureMonths { get; set; }
        public decimal Emi { get; set; }
        public string Status { get; set; } = string.Empty;
        public string ApprovedByName { get; set; } = string.Empty;
        public int? ApprovedBy { get; set; }
        public string? SanctionLetterPath { get; set; }
        public int WagesId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class LoanApprovalDto
    {
        public int loan_id { get; set; }
        public int approved_by { get; set; }
    }

    public class LoanFilterDto
    {
        public int? UserId { get; set; }
        public string? Status { get; set; }
    }
}
