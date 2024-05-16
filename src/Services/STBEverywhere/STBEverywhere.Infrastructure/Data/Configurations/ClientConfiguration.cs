using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STBEverywhere.Domain.Models;
using STBEverywhere.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Infrastructure.Data.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasConversion(
                clientId => clientId.Value,
                dbId => ClientId.Of(dbId));

            builder.HasMany(c => c.Comptes)
                   .WithOne()
                   .HasForeignKey("ClientId")
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(c => c.Cartes)
                   .WithOne()
                   .HasForeignKey("ClientId")
                   .OnDelete(DeleteBehavior.NoAction);

            // Adjust the foreign key property to match the primary key type
            builder.HasMany(c => c.CreditClients)
                   .WithOne()
                   .HasForeignKey("ClientId") // Assuming ClientId is a Guid
                   .OnDelete(DeleteBehavior.NoAction);


            builder.Property(c => c.Nom).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Prenom).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Email).HasMaxLength(255);
            builder.HasIndex(c => c.Email).IsUnique();
            builder.Property(c => c.Téléphone).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Adresse).HasMaxLength(100).IsRequired();
        }
    }


}
