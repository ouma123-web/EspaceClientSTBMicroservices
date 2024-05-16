using STBEverywhere.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Domain.Models
{
    public class CreditClient : Entity<CreditClientId>
    {
        //public Client Client { get; set; }
        //public Credit Credit { get; set; }


        //public string DateDeblocage { get; set; }
        //public decimal MontantDebloquer { get; set; }


        public ClientId ClientId { get; private set; }
        public CreditId CreditId { get; private set; }
        public string DateDeblocage { get; private set; }
        public decimal MontantDebloquer { get; private set; }

        // Navigation properties
        public Client Client { get; private set; }
        public Credit Credit { get; private set; }

        public CreditClient(ClientId clientId, CreditId creditId, string dateDeblocage, decimal montantDebloquer)
        {
            if (string.IsNullOrWhiteSpace(dateDeblocage))
                throw new ArgumentException("DateDeblocage cannot be null or empty.", nameof(dateDeblocage));
            if (montantDebloquer <= 0)
                throw new ArgumentException("MontantDebloquer must be positive.", nameof(montantDebloquer));

            ClientId = clientId;
            CreditId = creditId;
            DateDeblocage = dateDeblocage;
            MontantDebloquer = montantDebloquer;
        }
    }
}
