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
                .WithMany()
                .HasForeignKey(ccl => ccl.CreditId);

            builder.HasOne<Client>()
                   .WithMany()
                   .HasForeignKey(ccl => ccl.ClientId);


            // Other property configurations...
            builder.Property(ccl => ccl.DateDeblocage).HasMaxLength(100).IsRequired();
            builder.Property(ccl => ccl.MontantDebloquer).IsRequired();
        }

    }

}
