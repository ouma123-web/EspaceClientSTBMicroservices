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
    public class CarteConfigurations : IEntityTypeConfiguration<Carte>
    {
        public void Configure(EntityTypeBuilder<Carte> builder)
        {
            builder.HasKey(ca => ca.Id);
            builder.Property(ca => ca.Id).HasConversion(
                carteId => carteId.Value,
                dbId => CarteId.Of(dbId));



            builder.Property(ca => ca.Solde).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(ca => ca.CodeSecretCarte).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(ca => ca.NumCarte).IsRequired();
            builder.Property(ca => ca.DateExpiration).IsRequired();

            builder.Property(ca => ca.Status)
                .HasDefaultValue(CarteStatus.Débloqué)
                .HasConversion(
                    s => s.ToString(),
                    dbStatus => (CarteStatus)Enum.Parse(typeof(CarteStatus), dbStatus));

            builder.Property(ca => ca.Type)
                .HasDefaultValue(CarteType.CarteElectronique)
                .HasConversion(
                    s => s.ToString(),
                    dbType => (CarteType)Enum.Parse(typeof(CarteType), dbType));



        }
    }

}
