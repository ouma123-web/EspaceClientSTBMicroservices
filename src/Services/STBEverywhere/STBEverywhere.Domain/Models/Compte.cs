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
    public class Compte : Aggregate<CompteId>
    {



        public ClientId ClientId { get; set; }
        public OpérationId OpérationId { get; set; }
        public string NumCompte { get; set; } = string.Empty;
        public decimal Solde { get; set; }
        public DateTime DateOuverture { get; set; }
        public CompteType Type { get; private set; } = CompteType.CompteCheque;

        // Constructeur avec paramètres correspondant aux noms des propriétés
       /* public Compte(ClientId id, OpérationId opérationId, CompteType type, string numCompte, decimal solde, DateTime dateouverture)
        {
            Id = CompteId.Of(Guid.NewGuid());
            Type = type;
            NumCompte = numCompte;
            Solde = solde;
            this.DateOuverture = dateouverture;
        }
       */

        public static Compte Create(CompteId id, OpérationId opérationId, string numCompte, decimal solde, DateTime dateouverture)
        {
            var compte = new Compte
            {
                Id = id,
                OpérationId = opérationId,
                NumCompte = numCompte,
                Solde = solde,
                DateOuverture = dateouverture,
                Type = CompteType.CompteEpargne           };

           compte.AddDomainEvent(new CompteCreatedEvent(compte));

            return compte;

        }

       

        /*
        public string ConsulterCompte()
        {
            return $"ClientId: {ClientId}, NumCompte: {NumCompte}, Solde: {Solde}, DateOuverture: {DateOuverture}, Type:{Type}";
        }
        */



    }

}
