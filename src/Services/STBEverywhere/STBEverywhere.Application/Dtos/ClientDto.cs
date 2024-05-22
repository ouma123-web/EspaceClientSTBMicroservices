using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Application.Dtos
{
    public record ClientDto(
        Guid Id,
        string Nom,
        string Prenom,
        string Email,
        int Téléphone,
        string Adresse,
        List<CarteDto> CarteDtos,
        List<CompteDto> CompteDtos,
        List<CreditClientDto> CreditClientDtos
        );
    
}
