namespace VoteSystem.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "First name can not be less than 2 symbols.")]
        [MaxLength(20, ErrorMessage = "First name can not be greater than 20 symbols.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Last Name can not be less than 2 symbols.")]
        [MaxLength(20, ErrorMessage = "Last Name can not be greater than 20 symbols.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Range(10000, 9999999, ErrorMessage = "Faculty Number should be in the range between 10000 and 9999999")]
        [Display(Name = "Faculty Number")]
        public int FacultyNumber { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}