using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STBEverywhere.Domain.Abstractions;
using STBEverywhere.Domain.ValueObjects;
using System.Diagnostics;

namespace STBEverywhere.Domain.Models
{
    public class Compte : Entity<CompteId>
    {



        public ClientId ClientId { get; set; }

        public OpérationId OpérationId { get; set; }

      
        public string NumCompte { get; set; } = string.Empty;
        public decimal Solde { get; set; }

        public DateTime DateOuverture { get; set; }




     
        
        
        
        
        
        public string ConsulterCompte()
        {
            return $"ClientId: {ClientId}, NumCompte: {NumCompte}, Solde: {Solde}, DateOuverture: {DateOuverture}";
        }


      

    }

}
