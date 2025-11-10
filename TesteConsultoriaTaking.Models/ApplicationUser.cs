using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TesteConsultoriaTaking.Models
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(180)]
        public string FullName { get; set; }
    }
}
