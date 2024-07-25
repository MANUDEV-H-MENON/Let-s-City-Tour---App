namespace CityInfo.API.Services
{
    public class CloudMailService : IMailService
    {

        private string _mailTo = "cloudManudev.h.menon@gmail.com";
        private string _mailFrom = "cloudManudev.h.menon@gmail.com";

        public CloudMailService(IConfiguration configuration)
        {
            _mailTo = configuration["mailSettings:mailToAddress"];
            _mailFrom = configuration["mailSettings:mailFromAddress"];
        }

        public void Send(string subject, string message)
        {
            Console.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with {nameof(CloudMailService)}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {message}");

        }
    }
}
