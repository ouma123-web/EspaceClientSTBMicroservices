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
        public Client Client { get; set; }
        public Credit Credit { get; set; }

      
        public string DateDeblocage { get; set; }
        public decimal MontantDebloquer { get; set; }

    }
}
