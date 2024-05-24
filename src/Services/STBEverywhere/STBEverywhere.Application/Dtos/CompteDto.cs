using STBEverywhere.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Application.Dtos
{
    public record CompteDto(
        Guid ClientId,
        Guid OpérationId,
        Guid CompteId,
        string NumCompte,
        decimal Solde,
        DateTime DateOuverture,
        CompteType Type
        );
}
