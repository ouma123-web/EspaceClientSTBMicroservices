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
    public class CompteConfigurations : IEntityTypeConfiguration<Compte>
    {
        public void Configure(EntityTypeBuilder<Compte> builder)
        {
            builder.HasKey(co => co.Id); 
            builder.Property(co => co.Id).HasConversion(
                compteId => compteId.Value,
                dbId => CompteId.Of(dbId));


            builder.HasOne<Client>()
               .WithMany()
               .HasForeignKey(c => c.ClientId);


            builder.HasOne<Opération>()
                .WithMany()
                .HasForeignKey(o => o.OpérationId);


          

            builder.Property(co => co.NumCompte).IsRequired();

            builder.Property(co => co.Solde).IsRequired();

            builder.Property(co => co.DateOuverture).IsRequired();
        }



        }
}
