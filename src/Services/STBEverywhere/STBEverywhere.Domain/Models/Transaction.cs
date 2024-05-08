using STBEverywhere.Domain.Abstractions;
using STBEverywhere.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace STBEverywhere.Domain.Models
{
    public class Transaction : Entity<TransactionId>
    {
        private readonly List<Compte> _comptes = new();
        public IReadOnlyList<Compte> Comptes => _comptes.AsReadOnly();

        public string Visualisation { get; set; }
        public decimal Montant { get; set; }
        public TransactionType Type { get; set; }

        public Transaction(TransactionType type, string visualisation, decimal montant)
        {
            Type = type;
            Visualisation = visualisation;
            Montant = montant;
        }
    }
}
