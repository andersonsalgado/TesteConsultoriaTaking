using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using TesteConsultoriaTaking.Models;

namespace TesteConsultoriaTaking.Migrations
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ClienteModel> ClienteModel { get; set; }

        public DatabaseContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected DatabaseContext()
        {
        }
    }
}
