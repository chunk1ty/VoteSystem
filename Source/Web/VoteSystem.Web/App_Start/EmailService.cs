namespace VoteSystem.Web
{
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using SendGrid;
    using System;

    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            await configSendGridasync(message);
        }

        // Use NuGet to install SendGrid (Basic C# client lib) 
        private async Task configSendGridasync(IdentityMessage message)
        {
            var myMessage = new SendGridMessage();

            myMessage.AddTo(message.Destination);
            myMessage.From = new System.Net.Mail.MailAddress("andriyan.krastev@gmail.com", "AK");
            myMessage.Subject = message.Subject;
            myMessage.Html = message.Body;

            var transportWeb = new Web("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");
            try
            {
                // Send the email.
                if (transportWeb != null)
                {
                    await transportWeb.DeliverAsync(myMessage);
                }
                else
                {
                    //Trace.TraceError("Failed to create Web transport.");
                    await Task.FromResult(0);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}