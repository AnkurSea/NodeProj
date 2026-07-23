namespace XUnitTest.Services
{
    public class EmailService: IEmailService
    {
        public EmailService() { }
        public string SendEmail(string to, string subject, string body)
        {
            // Simulate sending an email
            return $"Email sent to {to} with subject '{subject}' and body '{body}'";
        }   
    }

    public interface IEmailService
    {
        string SendEmail(string to, string subject, string body);
    }   
}
