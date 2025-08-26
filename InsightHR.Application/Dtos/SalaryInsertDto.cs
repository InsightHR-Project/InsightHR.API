using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Application.Dtos
{
    public class SalaryInsertDto
    {
        public int SalaryId { get; set; }
        public decimal Deductions { get; set; }
        public string PayPeriod { get; set; }

        public class SalaryByIdDto
        {
            public int Id { get; set; }
        }
    }
}
