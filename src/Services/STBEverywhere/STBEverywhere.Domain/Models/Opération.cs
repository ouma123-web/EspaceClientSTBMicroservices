using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Domain.Models
{
    public class Opération :Entity<OpérationId>
    {

        private readonly List<Compte> _comptes = new();
        public IReadOnlyList<Compte> Comptes => _comptes.AsReadOnly();


        public string Visualisation { get; set; }
        public decimal Montant { get; set; }
        public OpérationType Type { get; set; } = OpérationType.In;

        public Opération(OpérationType type, string visualisation, decimal montant)
        {
            Type = type;
            Visualisation = visualisation;
            Montant = montant;
        }
    }
}
