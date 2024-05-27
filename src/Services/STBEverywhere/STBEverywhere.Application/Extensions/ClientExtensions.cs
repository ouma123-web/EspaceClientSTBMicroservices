

namespace STBEverywhere.Application.Extensions
{
    public static class ClientExtensions
    {
        public static IEnumerable<ClientDto> ToClientDtoList(this IEnumerable<Client> clients)
        {
            return clients.Select(client => new ClientDto(
                Id: client.Id.Value,
                Nom: client.Nom,
                Prenom: client.Prenom,
                Email: client.Email,
                Téléphone: client.Téléphone,
                Adresse: client.Adresse,
                Comptes: client.Comptes.Select(co => new CompteDto(co.CompteId.Value, co.ClientId.Value, co.OpérationId.Value, co.NumCompte, co.Solde, co.DateOuverture,co.Type)).ToList(),
                Cartes: client.Cartes.Select(ca => new CarteDto(ca.Id.Value, ca.ClientId.Value, ca.NumCarte, ca.Solde, ca.CodeSecretCarte, ca.DateExpiration, ca.Status, ca.Type)).ToList(),
                CreditClients: client.CreditClients.Select(ccl => new CreditClientDto(ccl.Id.Value, ccl.ClientId.Value, ccl.CreditId.Value, ccl.DateDeblocage, ccl.MontantDebloquer)).ToList()
                ));
        }

        public static ClientDto ToClientDto(this Client client)
        {
            return DtoFromClient(client);
        }

        private static ClientDto DtoFromClient(Client client)
        {
            return new ClientDto(
                      Id: client.Id.Value,
                Nom: client.Nom,
                Prenom: client.Prenom,
                Email: client.Email,
                Téléphone: client.Téléphone,
                Adresse: client.Adresse,
                Comptes: client.Comptes.Select(co => new CompteDto(co.CompteId.Value, co.ClientId.Value, co.OpérationId.Value, co.NumCompte, co.Solde, co.DateOuverture, co.Type)).ToList(),
                Cartes: client.Cartes.Select(ca => new CarteDto(ca.Id.Value, ca.ClientId.Value, ca.NumCarte, ca.Solde, ca.CodeSecretCarte, ca.DateExpiration, ca.Status, ca.Type)).ToList(),
                CreditClients: client.CreditClients.Select(ccl => new CreditClientDto(ccl.Id.Value, ccl.ClientId.Value, ccl.CreditId.Value, ccl.DateDeblocage, ccl.MontantDebloquer)).ToList()
                 );
        }
    }
}
