using System.Net;
using System.Net.Mail;

public class EmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendAppointmentEmailAsync(
        string recipientEmail,
        string patientName,
        DateTime appointmentDate)
    {
        string senderEmail =
            _configuration["EmailSettings:SenderEmail"]!;

        string senderName =
            _configuration["EmailSettings:SenderName"]!;

        string appPassword =
            _configuration["EmailSettings:AppPassword"]!;

        string smtpServer =
            _configuration["EmailSettings:SmtpServer"]!;

        int port =
            Convert.ToInt32(
                _configuration["EmailSettings:Port"]);

        using var client = new SmtpClient(smtpServer, port);

        client.Credentials =
            new NetworkCredential(senderEmail, appPassword);

        client.EnableSsl = true;

        using var message = new MailMessage();

        message.From =
            new MailAddress(senderEmail, senderName);

        message.To.Add(recipientEmail);

        message.Subject =
            "Appointment Confirmation";

        message.Body =
$@"Hello {patientName},

Your appointment has been booked successfully.

Appointment Date:
{appointmentDate:dd-MMM-yyyy hh:mm tt}

Thank You,
{senderName}";

        await client.SendMailAsync(message);
    }
}