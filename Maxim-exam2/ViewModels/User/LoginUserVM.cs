using System.ComponentModel.DataAnnotations;

namespace Maxim_exam2.ViewModels
{
    public class LoginUserVM
    {
        [Required]
        public string UsernameorEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string IsResistance { get; set; }
    }
}
