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
    public class OpérationConfigurations : IEntityTypeConfiguration<Opération>
    {
        public void Configure(EntityTypeBuilder<Opération> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).HasConversion(
                opérationId => opérationId.Value,
                dbId => OpérationId.Of(dbId));


            builder.HasMany(co => co.Comptes);
               /* .WithOne()
                .HasForeignKey(o => o.OpérationId);*/



            builder.Property(o => o.Visualisation).HasMaxLength(100).IsRequired();

            builder.Property(o => o.Montant).IsRequired();

            builder.Property(o => o.Type)
            .HasDefaultValue(OpérationType.Out)
            .HasConversion(
                s => s.ToString(),
                dbStatus => (OpérationType)Enum.Parse(typeof(OpérationType), dbStatus));






        }
    }
}
