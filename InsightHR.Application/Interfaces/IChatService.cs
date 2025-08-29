using InsightHR.Application.Dtos;
using InsightHR.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Application.Interfaces
{
    public interface IChatService
    {
        Task<ApiResponse<string>> SendMessage(int senderId, ChatMessageDto message);
        Task<ApiResponse<dynamic>> GetConversation(int senderId, int receiverId);
        Task<ApiResponse<dynamic>> GetMessagesBySender(int senderId);
        Task<ApiResponse<dynamic>> GetMessagesByReceiver(int receiverId);
        Task<ApiResponse<string>> UpdateMessage(int senderId, int messageId, string newMessage);
        Task<ApiResponse<string>> DeleteMessage(int messageId);
        Task<ApiResponse<dynamic>> GetRecentMessages();
        Task<ApiResponse<dynamic>> GetAllMessages();
    }
}
