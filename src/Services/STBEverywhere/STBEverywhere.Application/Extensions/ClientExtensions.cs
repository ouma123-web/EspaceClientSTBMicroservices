using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Application.Extensions
{
    public static class ClientExtensions
    {
        public static IEnumerable<ClientDto> ToClientDtoList(this IEnumerable<Client> clients)
        {
            return clients.Select(client => new ClientDto(
                ClientId: client.Id.Value,
                Nom: client.Nom,
                Prenom: client.Prenom,
                Email: client.Email,
                Téléphone: client.Téléphone,
                Adresse: client.Adresse,
                Comptes: client.Comptes.Select(co => new CompteDto(co.ClientId.Value, co.OpérationId.Value, co.NumCompte, co.Solde, co.DateOuverture,co.Type)).ToList(),
                Cartes: client.Cartes.Select(ca => new CarteDto(ca.ClientId.Value, ca.NumCarte, ca.Solde, ca.CodeSecretCarte, ca.DateExpiration, ca.Status, ca.Type)).ToList(),
                CreditClients: client.CreditClients.Select(ccl => new CreditClientDto(ccl.ClientId.Value, ccl.CreditId.Value, ccl.DateDeblocage, ccl.MontantDebloquer)).ToList()
                ));
        }
    }
}
