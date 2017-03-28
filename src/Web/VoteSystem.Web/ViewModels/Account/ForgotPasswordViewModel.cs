namespace VoteSystem.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public class ForgotPasswordViewModel
    {        
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Имeйла е задължителен.")]
        [EmailAddress(ErrorMessage = "Невалиден имейл формат.")]
        public string Email { get; set; }
    }
}