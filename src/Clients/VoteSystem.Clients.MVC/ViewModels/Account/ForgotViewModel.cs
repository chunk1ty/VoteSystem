using System.ComponentModel.DataAnnotations;

namespace VoteSystem.Clients.MVC.ViewModels.Account
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}