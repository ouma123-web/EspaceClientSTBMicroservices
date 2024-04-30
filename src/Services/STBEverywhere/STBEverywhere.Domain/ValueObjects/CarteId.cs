using STBEverywhere.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Domain.ValueObjects
{
    public record CarteId
    {
        public Guid Value { get; }
        private CarteId(Guid value) => Value = value;
        public static CarteId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("CarteId cannot be empty.");
            }

            return new CarteId(value);
        }
    }
}
