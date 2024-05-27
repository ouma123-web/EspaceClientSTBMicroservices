using STBEverywhere.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Domain.Models
{
    public class ClientCredit : Entity<CreditClientId>

    {

        public ClientId ClientId { get; set; }
        public CreditId CreditId { get; set; }

        public decimal MontantDebloquer { get; set; }
        public string DateDeblocage { get; set; }
        
    }
}
