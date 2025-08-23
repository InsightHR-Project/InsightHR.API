using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Shared.Results
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
        public int StatusCode { get; set; }

        public static ApiResponse<T> Ok(T data, string? message = null, int statusCode = 200) =>
            new ApiResponse<T> { Success = true, Data = data, Message = message, StatusCode = statusCode };

        public static ApiResponse<T> Fail(string message, int statusCode = 400) =>
            new ApiResponse<T> { Success = false, Message = message, StatusCode = statusCode };
    }
}
