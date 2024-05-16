using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STBEverywhere.Domain.Enums;
using STBEverywhere.Domain.Models;
using STBEverywhere.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Infrastructure.Data.Configurations
{
    public class CompteConfigurations : IEntityTypeConfiguration<Compte>
    {
        public void Configure(EntityTypeBuilder<Compte> builder)
        {
            builder.HasKey(co => co.Id);

            builder.Property(co => co.Id).HasConversion(
                compteId => compteId.Value,
                dbId => CompteId.Of(dbId));

            builder.HasOne<Client>()
                   .WithMany(c => c.Comptes)
                   .HasForeignKey("ClientId")
                   .OnDelete(DeleteBehavior.NoAction); // Spécifie OnDelete NoAction pour éviter les cascades

            builder.Property(co => co.OpérationId).IsRequired();
            builder.Property(co => co.NumCompte).IsRequired();
            builder.Property(co => co.Solde).IsRequired();
            builder.Property(co => co.DateOuverture).IsRequired();

            builder.Property(co => co.Type)
                   .HasDefaultValue(CompteType.CompteCheque)
                   .HasConversion(
                       s => s.ToString(),
                       dbType => (CompteType)Enum.Parse(typeof(CompteType), dbType));
        }
    }

}
