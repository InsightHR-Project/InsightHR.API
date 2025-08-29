using InsightHR.Application.Dtos;
using InsightHR.Application.Interfaces;
using InsightHR.Shared.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InsightHR.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Require authentication
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        // Helper to get current user ID safely
        private bool TryGetUserId(out int userId)
        {
            userId = 0;
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return !string.IsNullOrEmpty(userIdClaim) && int.TryParse(userIdClaim, out userId);
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] ChatMessageDto message)
        {
            if (!TryGetUserId(out var userId))
                return Unauthorized(ApiResponse<string>.Fail("Invalid token or missing user ID."));

            var result = await _chatService.SendMessage(userId, message);
            return Ok(result);
        }

        [HttpGet("conversation/{receiverId}")]
        public async Task<IActionResult> GetConversation(int receiverId)
        {
            if (!TryGetUserId(out var userId))
                return Unauthorized(ApiResponse<string>.Fail("Invalid token or missing user ID."));

            var result = await _chatService.GetConversation(userId, receiverId);
            return Ok(result);
        }

        [HttpGet("sender")]
        public async Task<IActionResult> GetMessagesBySender()
        {
            if (!TryGetUserId(out var userId))
                return Unauthorized(ApiResponse<string>.Fail("Invalid token or missing user ID."));

            var result = await _chatService.GetMessagesBySender(userId);
            return Ok(result);
        }

        [HttpGet("receiver")]
        public async Task<IActionResult> GetMessagesByReceiver()
        {
            if (!TryGetUserId(out var userId))
                return Unauthorized(ApiResponse<string>.Fail("Invalid token or missing user ID."));

            var result = await _chatService.GetMessagesByReceiver(userId);
            return Ok(result);
        }

        //[HttpPut("update/{messageId}")]
        //public async Task<IActionResult> UpdateMessage(int messageId, [FromBody] UpdateMessageDto dto)
        //{
        //    if (!TryGetUserId(out var userId))
        //        return Unauthorized(ApiResponse<string>.Fail("Invalid token or missing user ID."));

        //    var result = await _chatService.UpdateMessage(userId, messageId, dto.Message);
        //    return Ok(result);
        //}

        [HttpDelete("delete/{messageId}")]
        public async Task<IActionResult> DeleteMessage(int messageId)
        {
            if (!TryGetUserId(out var userId))
                return Unauthorized(ApiResponse<string>.Fail("Invalid token or missing user ID."));

            var result = await _chatService.DeleteMessage(messageId);
            return Ok(result);
        }

        [HttpGet("recent")]
        public async Task<IActionResult> GetRecentMessages()
        {
            if (!TryGetUserId(out var userId))
                return Unauthorized(ApiResponse<string>.Fail("Invalid token or missing user ID."));

            var result = await _chatService.GetRecentMessages();
            return Ok(result);
        }

        [HttpGet("all")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllMessages()
        {
            var result = await _chatService.GetAllMessages();
            return Ok(result);
        }
    }
}
