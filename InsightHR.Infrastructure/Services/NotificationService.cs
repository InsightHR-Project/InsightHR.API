using Application.Common.Interfaces;
using InsightHR.Persistence.Repositories;
using System;
using System.Threading.Tasks;

namespace InsightHR.Infrastructure.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IEmailService _emailService;
        private readonly IUserRepository _userRepository;

        public NotificationService(IEmailService emailService, IUserRepository userRepository)
        {
            _emailService = emailService;
            _userRepository = userRepository;
        }

        public async Task SendNotificationAsync(int userId, string message)
        {
            var user = await _userRepository.GetById(userId);

            Console.WriteLine($"[NotificationService] Checking user with Id={userId}");
            Console.WriteLine(user == null ? "User not found" : $"User email: {user?.email}");

            // use lowercase "email", because DB column is "email"
            string email = user?.email;

            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("User not found or has no email.");

            await _emailService.SendEmailAsync(email, "Notification", message);
        }
    }
}
