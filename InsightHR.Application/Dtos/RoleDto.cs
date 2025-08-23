using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Application.Dtos
{
    public class RoleDto
    {
        public string? Name { get; set; }   
    }

    public class RoleUpdateDto 
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
