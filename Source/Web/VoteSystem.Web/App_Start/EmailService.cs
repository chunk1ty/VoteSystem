namespace VoteSystem.Web
{
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using SendGrid;
    using System;
    using ViewModels.Introduction;
    using System.Collections.Generic;
    using Data.Models;

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

        public async Task SendAddedParticipantsAsync(List<string> participants, RateSystem rateSystem)
        {
            await AddedParticipantsAsync(participants, rateSystem);
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

        private async Task AddedParticipantsAsync(List<string> participants, RateSystem rateSystem)
        {
            var myMessage = new SendGridMessage();

            foreach (var participant in participants)
            {
                myMessage.AddTo(participant);
                myMessage.From = new System.Net.Mail.MailAddress("andriyan.krastev@gmail.com", "Система за гласуване.");
                myMessage.Subject = "Начало на система.";
                myMessage.Html = "Здравейте! Вие бяхте добавен към "+ rateSystem.RateSystemName + " система, която започва на "+ rateSystem.StarDateTime + " и свършва на " + rateSystem.EndDateTime + ". Моля отделете време и гласувайте. ";

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
}