using STBEverywhere.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Application.Dtos
{
    public record OpérationDto(
        Guid Id,
        string Visualisation,
        decimal Montant,
        OpérationType Type,
        List<CompteDto> Comptes
        );
}
