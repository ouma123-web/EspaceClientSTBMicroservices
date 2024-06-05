using STBEverywhere.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Application.Dtos
{
    public record CreditDto(
        Guid Id,
        string Code,
        decimal MaxMontant,
        string MaxDuree,
        CreditType Type,
        CreditStatus Status,
        List<CreditClientDto> CreditClients);
}
