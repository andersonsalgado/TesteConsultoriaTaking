using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TesteConsultoriaTaking.Models
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(180)]
        public string FullName { get; set; }
    }
}
