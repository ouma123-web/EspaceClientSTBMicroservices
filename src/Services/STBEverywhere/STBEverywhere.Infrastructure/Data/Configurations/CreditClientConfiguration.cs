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
    public class CreditClientConfiguration : IEntityTypeConfiguration<CreditClient>
    {
        public void Configure(EntityTypeBuilder<CreditClient> builder)
        {
            builder.HasKey(ccl => ccl.Id);
            builder.Property(ccl => ccl.Id).HasConversion(
                creditClientId => creditClientId.Value,
                dbId => CreditClientId.Of(dbId));

            builder.HasOne<Credit>()
                    .WithMany(ccl => ccl.CreditClients)
                    .HasForeignKey("CreditId")
                    .OnDelete(DeleteBehavior.NoAction); // Spécifie OnDelete NoAction pour éviter les cascades

            builder.HasOne<Client>()
                   .WithMany(ccl => ccl.CreditClients)
                   .HasForeignKey("ClientId")
                   .OnDelete(DeleteBehavior.NoAction); // Spécifie OnDelete NoAction pour éviter les cascades


            // Other property configurations...
            builder.Property(ccl => ccl.DateDeblocage).HasMaxLength(100).IsRequired();
            builder.Property(ccl => ccl.MontantDebloquer).IsRequired();
        }

    }

}
