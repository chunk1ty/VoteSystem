namespace VoteSystem.Web.ViewModels.Introduction
{
    using System.ComponentModel.DataAnnotations;

    public class FeedbackViewModel
    {
        [Required(ErrorMessage = "Името е задължително.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Темата е задължителна.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Имайла е задължителен.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Съобщението е задължително.")]
        public string Message { get; set; }
    }
}