using ClaimManager.Application.DTOs.Mail;
using System.Threading.Tasks;

namespace ClaimManager.Application.Interfaces.Shared
{
    public interface IMailService
    {
        Task SendAsync(MailRequest request);
    }
}