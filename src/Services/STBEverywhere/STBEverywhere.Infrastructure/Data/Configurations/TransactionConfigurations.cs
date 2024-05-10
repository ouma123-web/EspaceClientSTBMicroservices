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
    public class TransactionConfigurations
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasConversion(
                transactionId => transactionId.Value,
                dbId => TransactionId.Of(dbId));


            builder.HasMany(t => t.Comptes)
                .WithOne()
                .HasForeignKey(co => co.TransactionId);

            builder.Property(c => c.Visualisation).HasMaxLength(100).IsRequired();

            builder.Property(ca => ca.Montant).IsRequired();

            builder.Property(t => t.Type)
            .HasDefaultValue(TransactionType.Out)
            .HasConversion(
                s => s.ToString(),
                dbStatus => (TransactionType)Enum.Parse(typeof(TransactionType), dbStatus));


        }

        }
    }
