using Microsoft.EntityFrameworkCore;
using STBEverywhere.Application.Data;
using STBEverywhere.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Compte> Comptes => Set<Compte>();
        
        public DbSet<Carte> Cartes => Set<Carte>();
      
        public DbSet<Opération> Opérations => Set<Opération>();
        public DbSet<Credit> Credits => Set<Credit>();
        public DbSet<CreditClient> CreditClients => Set<CreditClient>();


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);

            


           
        }


       

    }
}
