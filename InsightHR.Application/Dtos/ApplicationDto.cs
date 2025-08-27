using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Application.Dtos
{
    public class ApplicationDto
    {
        public int JobId { get; set; }
        public string ApplicantName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? ResumePath { get; set; }
    }


    public class ApplicationUpdateDto
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public string ApplicantName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? ResumePath { get; set; }
        public string Status { get; set; } = "Applied";
        public DateTime? InterviewDate { get; set; }
        public int? ManagerId { get; set; }
        public string? Feedback { get; set; }
    }

    public class ScheduleInterviewDto
    {
        public int Id { get; set; }
        public DateTime InterviewDate { get; set; }
        public int ManagerId { get; set; }
    }

    public class FinalSelectionDto
    {
        public int Id { get; set; }
        public string Status { get; set; } = string.Empty; // "Hired" or "Rejected"
        public string? Feedback { get; set; }
    }

}
