using Microsoft.EntityFrameworkCore;
using STBEverywhere.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Application.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Client> Clients { get; }
        DbSet<Compte> Comptes { get; }
        DbSet<Carte> Cartes { get; }
        DbSet<Opération> Opérations { get; }
        DbSet<Credit> Credits { get; }
        DbSet<ClientCredit> CreditClients { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
