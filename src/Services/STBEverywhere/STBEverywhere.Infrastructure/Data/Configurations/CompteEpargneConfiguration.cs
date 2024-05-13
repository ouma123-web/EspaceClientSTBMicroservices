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
    public class CompteEpargneConfiguration : IEntityTypeConfiguration<CompteEpargne>
    {
        public void Configure(EntityTypeBuilder<CompteEpargne> builder)
        {
            

            builder.Property(cep => cep.TauxDeRemuneration).IsRequired();

        }

    }
}
