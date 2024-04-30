﻿using STBEverywhere.Domain.Abstractions;
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
        public string Visualisation { get; set; }
        public decimal Montant { get; set; }

        public IList<CompteTransaction> CompteTransaction { get; set; }

    }
}
