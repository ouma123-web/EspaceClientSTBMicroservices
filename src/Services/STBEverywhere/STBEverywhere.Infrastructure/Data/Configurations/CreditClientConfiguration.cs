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
    public class CreditClientConfiguration : IEntityTypeConfiguration<ClientCredit>
    {
        public void Configure(EntityTypeBuilder<ClientCredit> builder)
        {


            builder.HasKey(ccl => ccl.Id);
            builder.Property(ccl => ccl.Id).HasConversion(
                creditclientId => creditclientId.Value,
                dbId => CreditClientId.Of(dbId));




            builder.Property(ccl => ccl.DateDeblocage)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(ccl => ccl.MontantDebloquer)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

        }
    }

}

