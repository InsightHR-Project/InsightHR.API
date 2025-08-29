using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Application.Dtos
{
    public class SalaryComponentInsertDto
    {
        public int WagesId { get; set; }

        public decimal Deductions { get; set; }
        public string PayPeriod { get; set; } = string.Empty; // yyyy-MM-dd
    }

    public class SalaryComponentResponseDto
    {
        public int Id { get; set; }
        public int WagesId { get; set; }

        public decimal Basic { get; set; }
        public decimal Bonus { get; set; }
        public decimal Deductions { get; set; }
        public decimal EPF { get; set; }
        public decimal ESI { get; set; }
        public decimal? EMI { get; set; }
        public DateTime PayPeriod { get; set; }
        public decimal GrossProfit { get; set; }
        public decimal NetProfit { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
