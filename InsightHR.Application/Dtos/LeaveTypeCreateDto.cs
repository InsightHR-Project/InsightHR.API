using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Application.Dtos
{
    public class LeaveTypeCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int MaxDaysPerYear { get; set; }
    }

    public class LeaveTypeUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int MaxDaysPerYear { get; set; }
    }

}
