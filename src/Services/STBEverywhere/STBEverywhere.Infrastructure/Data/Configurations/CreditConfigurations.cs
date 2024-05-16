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
    public class CreditConfigurations : IEntityTypeConfiguration<Credit>
    {
        public void Configure(EntityTypeBuilder<Credit> builder)
        {
            builder.HasKey(cr => cr.Id);

            builder.Property(cr => cr.Id).HasConversion(
                creditId => creditId.Value,
                dbId => CreditId.Of(dbId));



            builder.HasMany(cr => cr.CreditClients)
                              .WithOne()
                              .HasForeignKey(ccl => ccl.ClientId); // Assuming ClientId is a Guid

            builder.Property(cr => cr.Code).HasMaxLength(100).IsRequired();
            builder.Property(cr => cr.MaxDuree).HasMaxLength(100).IsRequired();
            builder.Property(cr => cr.MaxMontant).IsRequired();

            builder.Property(cr => cr.Type)
                   .HasDefaultValue(CreditType.Accepter)
                   .HasConversion(
                       s => s.ToString(),
                       dbStatus => (CreditType)Enum.Parse(typeof(CreditType), dbStatus));
        }
    }

}
