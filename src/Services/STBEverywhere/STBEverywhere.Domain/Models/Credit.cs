using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Domain.Models
{
    public class Credit : Entity<CreditId>

    {

        private readonly List<CreditClient> _creditclients = new();
        public IReadOnlyList<CreditClient> CreditClients => _creditclients.AsReadOnly();

        public string Code { get; set; }
        public decimal MaxMontant { get; set; }
        public string MaxDuree { get; set; }

        public CreditType Type { get; set; } = CreditType.Accepter;

        public Credit(CreditType type, string code, decimal maxMontant, string maxDuree)
        {
            Type = type;
            Code = code;
            MaxMontant = maxMontant;
            MaxDuree = maxDuree;

        }
    }
}
