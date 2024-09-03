using CleanArchitecture.Core.DTOs.Email;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
        Task SendEmail(string email, string verificationUri);
        Task SendMail(string recipient,string subject,string body);
    }
}
