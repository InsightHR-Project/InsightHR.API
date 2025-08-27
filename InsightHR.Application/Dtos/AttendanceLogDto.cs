using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Application.Dtos
{
    public class AttendanceLogDto
    {
        public int UserId { get; set; }
        public DateTime? PunchIn { get; set; }
        public DateTime? PunchOut { get; set; }
        public int ShiftId { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? IpAddress { get; set; }
        public string? NetworkName { get; set; }
    }

    public class AttendanceLogUpdateDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime? PunchIn { get; set; }
        public DateTime? PunchOut { get; set; }
        public int ShiftId { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? IpAddress { get; set; }
        public string? NetworkName { get; set; }
    }


}
