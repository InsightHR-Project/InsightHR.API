using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Application.Dtos
{
    public class WagesRequest
    {
        public int UserId { get; set; }
        public decimal EmployeeWages { get; set; }
    }
    public class WagesResponse
    {
        public int WageId { get; set; }

        public int UserId { get; set; }
        public Decimal employee_wages { get; set; }

        public DateTime created_at { get; set; }

        public DateTime updated_at { get; set; }
    }
    public class UpdateWagesRequest
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public decimal EmployeeWages { get; set; }
    }
    public class DeleteWagesRequest
    {
        public int Id { get; set; }
    }
    public class GetWagesByIdRequest
    {
        public int Id { get; set; }
    }

}
