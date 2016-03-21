namespace VoteSystem.Web
{
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using SendGrid;
    using System;
    using ViewModels.Introduction;

    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            await ConfigSendGridasync(message);
        }

        public async Task SendFeedbackEmailAsync(FeedbackViewModel message)
        {
            await FeedbackEmailAsync(message);
        }

        private async Task FeedbackEmailAsync(FeedbackViewModel message)
        {
            var myMessage = new SendGridMessage();

            myMessage.AddTo("andriyan.krastev@gmail.com");
            myMessage.From = new System.Net.Mail.MailAddress(message.Email, message.Name);
            myMessage.Subject = message.Subject;
            myMessage.Html = message.Message;

            var transportWeb = new Web("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");

            try
            {
                if (transportWeb != null)
                {
                    await transportWeb.DeliverAsync(myMessage);
                }
                else
                {
                    await Task.FromResult(0);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task ConfigSendGridasync(IdentityMessage message)
        {
            var myMessage = new SendGridMessage();

            myMessage.AddTo(message.Destination);
            myMessage.From = new System.Net.Mail.MailAddress("andriyan.krastev@gmail.com", "Система за гласуване.");
            myMessage.Subject = message.Subject;
            myMessage.Html = message.Body;

            var transportWeb = new Web("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");
            try
            {
                if (transportWeb != null)
                {
                    await transportWeb.DeliverAsync(myMessage);
                }
                else
                {
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