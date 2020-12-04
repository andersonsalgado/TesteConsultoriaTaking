using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using TesteConsultoriaTaking.Models;

namespace TesteConsultoriaTaking.Migrations
{
    public class DatabaseContext : DbContext
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
