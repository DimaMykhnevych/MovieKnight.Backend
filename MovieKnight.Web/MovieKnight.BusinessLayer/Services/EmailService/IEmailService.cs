using MovieKnight.DataLayer.Models;
using System.Threading.Tasks;

namespace MovieKnight.BusinessLayer.Services.EmailService
{
    public interface IEmailService
    {
        Task SendEmail(AppUser user, string url);
    }
}
