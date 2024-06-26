﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Application.Extensions
{
    public static class CompteExtensions
    {

        public static IEnumerable<CompteDto> ToCompteDtoList(this IEnumerable<Compte> comptes)
        {
            return comptes.Select(compte => new CompteDto(
                Id: compte.Id.Value,
                ClientId: compte.ClientId.Value,
                OpérationId: compte.OpérationId.Value,
                NumCompte: compte.NumCompte,
                Solde: compte.Solde,
                DateOuverture: compte.DateOuverture,
                Type: compte.Type
                ));
        }

        public static CompteDto ToCompteDto(this Compte compte)
        {
            return DtoFromCompte(compte);
        }


        private static CompteDto DtoFromCompte(Compte compte)
        {
            return new CompteDto(
                Id: compte.Id.Value,
                ClientId: compte.ClientId.Value,
                OpérationId: compte.OpérationId.Value,
                NumCompte: compte.NumCompte,
                Solde: compte.Solde,
                DateOuverture: compte.DateOuverture,
                Type: compte.Type
                    );
        }
    }
}

