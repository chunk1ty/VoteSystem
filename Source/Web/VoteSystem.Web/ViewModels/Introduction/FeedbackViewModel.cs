namespace VoteSystem.Web.ViewModels.Introduction
{
    using System.ComponentModel.DataAnnotations;

    public class FeedbackViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }
    }
}