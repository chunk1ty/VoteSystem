using System.ComponentModel.DataAnnotations;

namespace VoteSystem.Clients.MVC.ViewModels.Introduction
{
    public class FeedbackViewModel
    {
        [Required(ErrorMessage = "Името е задължително.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Темата е задължителна.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Имeйла е задължителен.")]
        [EmailAddress(ErrorMessage = "Невалиден имейл формат.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Съобщението е задължително.")]
        public string Message { get; set; }
    }
}