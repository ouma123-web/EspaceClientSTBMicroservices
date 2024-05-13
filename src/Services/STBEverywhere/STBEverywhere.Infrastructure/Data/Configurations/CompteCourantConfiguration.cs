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
    public class CompteCourantConfiguration : IEntityTypeConfiguration<CompteCourant>
    {
        public void Configure(EntityTypeBuilder<CompteCourant> builder)
        {
            

            builder.Property(cc => cc.AuthorisationDecouvert).IsRequired();

        }

    }
}
