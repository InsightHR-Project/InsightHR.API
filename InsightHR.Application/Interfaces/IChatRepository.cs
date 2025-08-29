using InsightHR.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Application.Interfaces
{
    public interface IChatRepository
    {
        Task<int> SendMessage(int senderId, ChatMessageDto message);
        Task<dynamic> GetConversation(int senderId, int receiverId);
        Task<dynamic> GetMessagesBySender(int senderId);
        Task<dynamic> GetMessagesByReceiver(int receiverId);
        Task<int> UpdateMessage(int senderId, int messageId, string newMessage);
        Task<int> DeleteMessage(int messageId);
        Task<dynamic> GetRecentMessages();
        Task<dynamic> GetAllMessages();
    }
}
