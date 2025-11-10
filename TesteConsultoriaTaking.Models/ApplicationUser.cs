using Microsoft.AspNetCore.Identity;

namespace TesteConsultoriaTaking.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
