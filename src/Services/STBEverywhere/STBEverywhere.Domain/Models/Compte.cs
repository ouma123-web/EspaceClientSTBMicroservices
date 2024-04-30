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


        [Key]
       // public int CompteId { get; set; }

        public ClientId ClientId { get; set; }
        public string NumCompte { get; set; } = string.Empty;
        public decimal Solde { get; set; }

        public DateTime DateOuverture { get; set; }


        public static Compte Create(CompteId id, string numCompte, decimal solde, DateTime dateOuverture)
        {
            var compte = new Compte
            {
                Id = id,
                NumCompte = numCompte,
                Solde = solde,
                DateOuverture = dateOuverture
            };

            return compte;
        }

    }



        /*  public int? ClientId { get; set; }


          [ForeignKey("ClientId")]

          public virtual Client Client { get; set; }*/
    
}
