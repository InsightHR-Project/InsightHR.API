using InsightHR.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Application.Interfaces
{
  
    public interface IAuthRepository
    {
        Task<int> Register(RegisterDto user);
        Task<dynamic> Login(string email);
    } 
}
