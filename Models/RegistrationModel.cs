using System.ComponentModel.DataAnnotations;

namespace AcademyMVC.Models
{
    public class RegistrationModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name ="User Name")]
        public string Email { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        [DataType(DataType.Password)]        
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string? Address2 { get; set; }
        [Required]
        [RegularExpression("^[A-Za-z]{1,2}[\\d]{1,2}([A-Za-z])?\\s?[\\d][A-Za-z]{2}$")]
        [Display(Name ="Post Code" )]
        public string PostCode { get; set; }
        [Display(Name = "Accept User Agreement")]
        public bool AcceptUserAgreement { get; set; }
        [Required]
        [RegularExpression("^[2-9]\\d{2}-\\d{3}-\\d{4}$")]
        public string PhoneNumber { get; set; }
        public string? RegistrationInValid { get; set;}




    }
}
