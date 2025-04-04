using System.ComponentModel.DataAnnotations;

namespace Company.Route.PL.DTOs
{
    public class ResetPasswordDto
    {
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "ConfirmPassword is Required")]
        [DataType(DataType.Password)]
        [Compare(nameof(NewPassword), ErrorMessage = "Confirm Password don't match password")]
        public string NewConfirmPassword { get; set; }
    }
}
