using STBEverywhere.Domain.Abstractions;
using STBEverywhere.Domain.ValueObjects;


namespace STBEverywhere.Domain.Models
{
    public class Carte : Entity<CarteId>
    {
        public ClientId ClientId { get; set; }
        public string NumCarte { get; set; } = null!;
        public decimal Solde { get; set; }
        public decimal CodeSecretCarte { get; set; }

        public DateOnly DateExpiration { get; set; }


        public string ConsulterCarte()
        {
            return $"ClientId: {ClientId}, NumCarte: {NumCarte}, CodeSecretCarte: {CodeSecretCarte}, DateExpiration: {DateExpiration}, Solde: {Solde}";
        }












        /*  public static Carte Create(CarteId id, string numCarte, decimal codeSecretCarte, DateOnly dateExpiration)
          {
              var carte = new Carte
              {
                  Id = id,
                  NumCarte = numCarte,
                  CodeSecretCarte = codeSecretCarte,
                  DateExpiration = dateExpiration
              };

              return carte;
          }
        */


    }
}
