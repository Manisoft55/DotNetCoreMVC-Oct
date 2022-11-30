using System.ComponentModel.DataAnnotations;

namespace MVCwithEFCoreV3.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Please enter your user name")]
        [MaxLength(25, ErrorMessage = "Please enter upto 25 characters")]
        [MinLength(3, ErrorMessage = "Please enter atleast 3 characters")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        [MaxLength(25, ErrorMessage = "Please enter upto 25 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
