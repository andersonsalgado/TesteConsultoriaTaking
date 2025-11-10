
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using TesteConsultoriaTaking.Models;

namespace TesteConsultoriaTaking.Migrations
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext()
        {
        }

        public DbSet<ClienteModel> ClienteModel { get; set; }

        //public DatabaseContext([NotNullAttribute] DbContextOptions options) : base(options)
        //{
        //}

        //protected DatabaseContext()
        //{
        //}

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //}
    }
}
