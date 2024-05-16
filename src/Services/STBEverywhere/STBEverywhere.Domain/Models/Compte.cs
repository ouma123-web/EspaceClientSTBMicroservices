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

        //// Constructeur avec paramètres correspondant aux noms des propriétés
        //public Compte(CompteType type, string numCompte, decimal solde, DateTime DateOuverture)
        //{
        //    Type = type;
        //    NumCompte = numCompte;
        //    Solde = solde;
        //    this.DateOuverture = DateOuverture;
        //}

        public Compte(ClientId clientId, OpérationId opérationId, CompteType type, string numCompte, decimal solde, DateTime dateOuverture)
        {
            if (string.IsNullOrWhiteSpace(numCompte)) throw new ArgumentException("NumCompte cannot be null or empty.", nameof(numCompte));
            if (dateOuverture > DateTime.Now) throw new ArgumentException("DateOuverture cannot be in the future.", nameof(dateOuverture));

            ClientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
            OpérationId = opérationId ?? throw new ArgumentNullException(nameof(opérationId));
            Type = type;
            NumCompte = numCompte;
            Solde = solde;
            DateOuverture = dateOuverture;
        }
        public string ConsulterCompte()
        {
            return $"ClientId: {ClientId}, NumCompte: {NumCompte}, Solde: {Solde}, DateOuverture: {DateOuverture}, Type:{Type}";
        }


        public void Credit(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount must be positive.", nameof(amount));
            Solde += amount;
        }

        public void Debit(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount must be positive.", nameof(amount));
            if (Solde < amount) throw new InvalidOperationException("Insufficient funds.");
            Solde -= amount;
        }

    }

}
