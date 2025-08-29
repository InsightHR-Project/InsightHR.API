using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Application.Dtos
{
    public class ChatMessageDto
    {
        public int ReceiverId { get; set; }     // Provided by client
        public string Message { get; set; }     // Message text

    }
}
