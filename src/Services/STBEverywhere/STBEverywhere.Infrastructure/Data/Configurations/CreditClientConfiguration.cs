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
            //builder.HasKey(ccl => ccl.Id);
            //builder.Property(ccl => ccl.Id).HasConversion(
            //    creditclientId => creditclientId.Value,
            //    dbId => CreditClientId.Of(dbId));


            //builder.HasOne<Client>()
            //    .WithMany()
            //.HasForeignKey("ClientId");

            //builder.HasOne<Credit>()
            //    .WithMany()
            //.HasForeignKey("CreditId");


            //builder.Property(ccl => ccl.DateDeblocage).HasMaxLength(100).IsRequired();

            //builder.Property(ccl => ccl.MontantDebloquer).IsRequired();


            builder.HasKey(ccl => ccl.Id);
            builder.Property(ccl => ccl.Id).HasConversion(
                creditclientId => creditclientId.Value,
                dbId => CreditClientId.Of(dbId));

            builder.HasOne(ccl => ccl.Client)
                .WithMany(client => client.CreditClients)
                .HasForeignKey(ccl => ccl.ClientId)
                .OnDelete(DeleteBehavior.Cascade); // Adjust as necessary

            builder.HasOne(ccl => ccl.Credit)
                .WithMany(credit => credit.CreditClients)
                .HasForeignKey(ccl => ccl.CreditId)
                .OnDelete(DeleteBehavior.Cascade); // Adjust as necessary

            builder.Property(ccl => ccl.DateDeblocage)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(ccl => ccl.MontantDebloquer)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

        }
    }
}
