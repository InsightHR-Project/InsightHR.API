using InsightHR.Application.Dtos;
using InsightHR.Application.Interfaces;
using InsightHR.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Infrastructure.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;

        public ChatService(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public async Task<ApiResponse<string>> SendMessage(int senderId, ChatMessageDto message)
        {
            await _chatRepository.SendMessage(senderId, message);
            return ApiResponse<string>.Ok("Message sent successfully.");
        }

        public async Task<ApiResponse<dynamic>> GetConversation(int senderId, int receiverId)
        {
            var conversation = await _chatRepository.GetConversation(senderId, receiverId);
            return ApiResponse<dynamic>.Ok(conversation, "Conversation retrieved successfully.");
        }

        public async Task<ApiResponse<dynamic>> GetMessagesBySender(int senderId)
        {
            var messages = await _chatRepository.GetMessagesBySender(senderId);
            return ApiResponse<dynamic>.Ok(messages, "Messages retrieved successfully.");
        }

        public async Task<ApiResponse<dynamic>> GetMessagesByReceiver(int receiverId)
        {
            var messages = await _chatRepository.GetMessagesByReceiver(receiverId);
            return ApiResponse<dynamic>.Ok(messages, "Messages retrieved successfully.");
        }

        public async Task<ApiResponse<string>> UpdateMessage(int senderId, int messageId, string newMessage)
        {
            await _chatRepository.UpdateMessage(senderId, messageId, newMessage);
            return ApiResponse<string>.Ok("Message updated successfully.");
        }

        public async Task<ApiResponse<string>> DeleteMessage(int messageId)
        {
            await _chatRepository.DeleteMessage(messageId);
            return ApiResponse<string>.Ok("Message deleted successfully.");
        }

        public async Task<ApiResponse<dynamic>> GetRecentMessages()
        {
            var messages = await _chatRepository.GetRecentMessages();
            return ApiResponse<dynamic>.Ok(messages, "Recent messages retrieved successfully.");
        }

        public async Task<ApiResponse<dynamic>> GetAllMessages()
        {
            var messages = await _chatRepository.GetAllMessages();
            return ApiResponse<dynamic>.Ok(messages, "All messages retrieved successfully.");
        }
    }
}
