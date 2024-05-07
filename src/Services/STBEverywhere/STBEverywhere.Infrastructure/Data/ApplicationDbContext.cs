using Microsoft.EntityFrameworkCore;
using STBEverywhere.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Compte> Comptes => Set<Compte>();
        public DbSet<CompteCheque> CompteCheques => Set<CompteCheque>();
        public DbSet<CompteCourant> CompteCourants => Set<CompteCourant>();
        public DbSet<CompteEnDevise> CompteEnDevises => Set<CompteEnDevise>();
        public DbSet<CompteEpargne> CompteEpargnes => Set<CompteEpargne>();
        public DbSet<Carte> Cartes => Set<Carte>();
        public DbSet<CarteElectronique> CarteElectroniques => Set<CarteElectronique>();
        public DbSet<CarteVisaPremier> CarteVisaPremiers => Set<CarteVisaPremier>();
        public DbSet<Transaction> Transactions => Set<Transaction>();
        public DbSet<CompteTransaction> CompteTransactions => Set<CompteTransaction>();


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }


    }
}
