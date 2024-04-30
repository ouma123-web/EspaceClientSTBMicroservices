using STBEverywhere.Domain.Abstractions;
using STBEverywhere.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Domain.Models
{
    internal class Carte : Entity<CarteId>
    {
        public ClientId ClientId { get; set; }
        public string NumCarte { get; set; } = null!;

        public decimal CodeSecretCarte { get; set; }

        public DateOnly DateExpiration { get; set; }
    }
}
