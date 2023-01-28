using Microsoft.AspNetCore.Identity;

namespace Maxim_exam2.Models.Base
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
