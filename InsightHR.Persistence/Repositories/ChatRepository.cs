using Dapper;
using InsightHR.Application.Dtos;
using InsightHR.Application.Interfaces;
using InsightHR.Persistence.Context;
using System.Data;
using System.Text.Json;
using System.Threading.Tasks;

namespace InsightHR.Persistence.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly DapperContext _context;

        public ChatRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> SendMessage(int senderId, ChatMessageDto message)
        {
            using var conn = _context.CreateConnection();
            var json = JsonSerializer.Serialize(new { receiver_id = message.ReceiverId, message = message.Message });
            return await conn.ExecuteAsync(
                "[dbo].[sp_ChatMessages]",
                new { Flag = 1, JsonData = json, SenderId = senderId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<dynamic> GetConversation(int senderId, int receiverId)
        {
            using var conn = _context.CreateConnection();
            return await conn.QueryAsync<dynamic>(
                "[dbo].[sp_ChatMessages]",
                new { Flag = 2, SenderId = senderId, ReceiverId = receiverId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<dynamic> GetMessagesBySender(int senderId)
        {
            using var conn = _context.CreateConnection();
            return await conn.QueryAsync<dynamic>(
                "[dbo].[sp_ChatMessages]",
                new { Flag = 3, SenderId = senderId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<dynamic> GetMessagesByReceiver(int receiverId)
        {
            using var conn = _context.CreateConnection();
            return await conn.QueryAsync<dynamic>(
                "[dbo].[sp_ChatMessages]",
                new { Flag = 4, ReceiverId = receiverId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> UpdateMessage(int senderId, int messageId, string newMessage)
        {
            using var conn = _context.CreateConnection();
            var json = JsonSerializer.Serialize(new { message_id = messageId, message = newMessage });
            return await conn.ExecuteAsync(
                "[dbo].[sp_ChatMessages]",
                new { Flag = 7, JsonData = json, SenderId = senderId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> DeleteMessage(int messageId)
        {
            using var conn = _context.CreateConnection();
            var json = JsonSerializer.Serialize(new { message_id = messageId });
            return await conn.ExecuteAsync(
                "[dbo].[sp_ChatMessages]",
                new { Flag = 5, JsonData = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<dynamic> GetRecentMessages()
        {
            using var conn = _context.CreateConnection();
            return await conn.QueryAsync<dynamic>(
                "[dbo].[sp_ChatMessages]",
                new { Flag = 6 },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<dynamic> GetAllMessages()
        {
            using var conn = _context.CreateConnection();
            return await conn.QueryAsync<dynamic>(
                "[dbo].[sp_ChatMessages]",
                new { Flag = 8 },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
