using Microsoft.Extensions.Options;
using MovieKnight.BusinessLayer.Options;
using MovieKnight.DataLayer.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MovieKnight.BusinessLayer.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly EmailServiceDetails _emailServiceDetails;

        public EmailService(IOptions<EmailServiceDetails> options)
        {
            _emailServiceDetails = options.Value;
        }

        public async Task SendEmail(AppUser user, string url)
        {
            MailAddress addressFrom = new MailAddress(_emailServiceDetails.EmailAddress, "Movie Knight");
            MailAddress addressTo = new MailAddress(user.Email);
            MailMessage message = new MailMessage(addressFrom, addressTo);

            message.Subject = "Account Confirmation";
            message.IsBodyHtml = true;
            string htmlString = @$"<html>
                      <body style='background-color: #f7f1d5; 
                        padding: 15px; border-radius: 15px; 
                        box-shadow: 5px 5px 15px 5px #9F9F9F;
                        font-size: 16px;'>
                      <p>Hello {user.UserName},</p>
                      <p>Please, confirm your account by clicking the following link.</p>
                      <a href={url}>Confirm Account</a>
                         <p>Thank you,<br>-Movie Knight</br></p>
                      </body>
                      </html>
                     ";
            message.Body = htmlString;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential(_emailServiceDetails.EmailAddress, _emailServiceDetails.Password);
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(message);
        }
    }
}
