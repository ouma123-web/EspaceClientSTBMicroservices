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

        internal Compte(ClientId clientId, string numcompte, decimal solde, DateTime dateouverture)
        {
            Id = CompteId.Of(Guid.NewGuid());
            ClientId = clientId;
            NumCompte = numcompte;
            Solde = solde;
            DateOuverture = dateouverture;
        }



        [Key]
       // public int CompteId { get; set; }

        public ClientId ClientId { get; set; }
        public string NumCompte { get; set; } = string.Empty;
        public decimal Solde { get; set; }

        public DateTime DateOuverture { get; set; }





      /*  public int? ClientId { get; set; }


        [ForeignKey("ClientId")]

        public virtual Client Client { get; set; }*/
    }
}
