using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Application.Dtos
{
    public class JobCreateDto
    {
        public string Title { get; set; }
        public int DepartmentId { get; set; }
        public bool Status { get; set; }
        public int CreatedBy { get; set; }
    }

    public class JobUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int DepartmentId { get; set; }
        public bool Status { get; set; }
    }
}
