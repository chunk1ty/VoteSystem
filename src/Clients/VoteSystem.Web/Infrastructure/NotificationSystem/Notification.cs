using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace VoteSystem.Clients.MVC.Infrastructure.NotificationSystem
{
    public static class NotificationExtensions
    {
        private static IDictionary<NotificationType, String> NotificationKey = new Dictionary<NotificationType, String>
        {
            { NotificationType.ERROR, "App.Notifications.Error" },
            { NotificationType.WARNING, "App.Notifications.Warning" },
            { NotificationType.SUCCESS, "App.Notifications.Success" },
            { NotificationType.INFO, "App.Notifications.Info" }
        };

        public static void AddNotification(this ControllerBase controller, String message, NotificationType notificationType)
        {
            string NotificationKey = GetNotificationKeyByType(notificationType);

            ICollection<String> messages = controller.TempData[NotificationKey] as ICollection<String>;

            if (messages == null)
            {
                controller.TempData[NotificationKey] = (messages = new HashSet<String>());
            }

            messages.Add(message);
        }

        public static IEnumerable<String> GetNotifications(this HtmlHelper htmlHelper, NotificationType notificationType)
        {
            string NotificationKey = GetNotificationKeyByType(notificationType);

            return htmlHelper.ViewContext.Controller.TempData[NotificationKey] as ICollection<String> ?? null;
        }

        private static string GetNotificationKeyByType(NotificationType notificationType)
        {
            try
            {
                return NotificationKey[notificationType];
            }
            catch (IndexOutOfRangeException e)
            {
                ArgumentException exception = new ArgumentException("Key is invalid", "notificationType", e);
                throw exception;
            }
        }
    }
}
