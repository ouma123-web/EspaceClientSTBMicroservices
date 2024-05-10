using STBEverywhere.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Domain.ValueObjects
{
    public record TransactionId
    {
        public Guid Value { get; }
        private TransactionId() // Constructeur public sans paramètres pour EF Core
        {
            Value = Guid.NewGuid(); // Initialisez la valeur par défaut si nécessaire
        }
        private TransactionId(Guid value) => Value = value;
        public static TransactionId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("TransactionId cannot be empty.");
            }

            return new TransactionId(value);
        }
    }
}
