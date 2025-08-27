using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Application.Dtos
{
    public class PerformanceReviewDto
    {
        public int UserId { get; set; }
        public string ReviewPeriod { get; set; } = string.Empty;
        public int? Score { get; set; }
        public string? Comments { get; set; }
    }

    public class PerformanceReviewUpdateDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ReviewPeriod { get; set; } = string.Empty;
        public int? Score { get; set; }
        public string? Comments { get; set; }
    }

    public class PerformanceReviewDeleteDto
    {
        public int Id { get; set; }
    }
}
