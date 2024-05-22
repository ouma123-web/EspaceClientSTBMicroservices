using STBEverywhere.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Application.Dtos
{
    public record CarteDto(
        Guid ClientId,
        string NumCarte,
        decimal Solde,
        decimal CodeSecretCarte,
        DateOnly DateExpiration,
        CarteStatus Status,
        CarteType Type
    );
}
