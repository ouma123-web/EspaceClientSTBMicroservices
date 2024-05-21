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
using System.Reflection.Metadata;

namespace STBEverywhere.Domain.Models
{
    public class Compte : Entity<CompteId>
    {



        public ClientId ClientId { get; set; }
        public OpérationId OpérationId { get; set; }
        public string NumCompte { get; set; } = string.Empty;
        public decimal Solde { get; set; }
        public DateTime DateOuverture { get; set; }
        public CompteType Type { get; private set; } = CompteType.CompteCheque;

        // Constructeur avec paramètres correspondant aux noms des propriétés
        public Compte(ClientId id, OpérationId opérationId, CompteType type, string numCompte, decimal solde, DateTime DateOuverture)
        {
            Id = CompteId.Of(Guid.NewGuid());
            Type = type;
            NumCompte = numCompte;
            Solde = solde;
            this.DateOuverture = DateOuverture;
        }

        /*
        public string ConsulterCompte()
        {
            return $"ClientId: {ClientId}, NumCompte: {NumCompte}, Solde: {Solde}, DateOuverture: {DateOuverture}, Type:{Type}";
        }
        */

      

    }

}
