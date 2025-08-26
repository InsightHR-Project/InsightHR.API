using InsightHR.Application.Dtos;
using InsightHR.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Application.Interfaces
{
    public interface IAuthService
    {
        Task<ApiResponse<string>> Register(RegisterDto user);
        Task<ApiResponse<AuthResponseDto>> Login(LoginDto login);
    }
}
