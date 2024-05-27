using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Domain.Models
{
    public class Credit : Aggregate<CreditId>

    {

        private readonly List<ClientCredit> _creditclients = new();
        public IReadOnlyList<ClientCredit> CreditClients => _creditclients.AsReadOnly();

        public string Code { get; set; }
        public decimal MaxMontant { get; set; }
        public string MaxDuree { get; set; }

        public CreditType Type { get; set; } = CreditType.Accepter;

       /* public Credit(CreditId creditId, CreditType type, string code, decimal maxMontant, string maxDuree)
        {
            Type = type;
            Code = code;
            MaxMontant = maxMontant;
            MaxDuree = maxDuree;

        }
       */

        public static Credit Create(CreditId creditId,  string code, decimal maxmontant, string maxduree)
        {
            var credit = new Credit
            {
                Id = creditId,
                Code = code,
                MaxMontant = maxmontant,
                MaxDuree = maxduree, 
                Type = CreditType.Accepter
            };

            credit.AddDomainEvent(new CreditCreatedEvent(credit));

            return credit;

        }

        /*public void Add(ClientId clientId, string datedeblocage, decimal montantdebloquer)
        {
            //ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(montantdebloquer);


            var clientcredit = new ClientCredit(Id, clientId, datedeblocage, montantdebloquer);
            _creditclients.Add(clientcredit);
        }
        */


        public void Update(string code, string maxduree, decimal maxmontant)
        {
          /*  Code = code;
            MaxDuree = maxduree;
            MaxMontant = maxmontant;

            AddDomainEvent(new CreditUpdatedEvent(this));
          */
        }


    }

    
}
