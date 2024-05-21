using STBEverywhere.Domain.Abstractions;
using STBEverywhere.Domain.ValueObjects;


namespace STBEverywhere.Domain.Models
{
    public class Carte : Aggregate<CarteId>
    {
        public ClientId ClientId { get; set; }
        public string NumCarte { get; set; } = null!;
        public decimal Solde { get; set; }
        public decimal CodeSecretCarte { get; set; }
        public DateOnly DateExpiration { get; set; }
        public CarteStatus Status { get; private set; } = CarteStatus.Bloqué;
        public CarteType Type { get; private set; } = CarteType.CarteElectronique;

        // Constructeur avec paramètres correspondant aux noms des propriétés
        public Carte(CarteType type, string numCarte, decimal solde, decimal codeSecretCarte, DateOnly dateExpiration, CarteStatus status)
        {
            Type = type;
            NumCarte = numCarte;
            Solde = solde;
            CodeSecretCarte = codeSecretCarte;
            DateExpiration = dateExpiration;
            Status = status;
        }

        /*
        public string ConsulterCarte()
        {
            return $"ClientId: {ClientId}, NumCarte: {NumCarte}, CodeSecretCarte: {CodeSecretCarte}, DateExpiration: {DateExpiration}, Solde: {Solde}, Status: {Status}, Type: {Type}";
        }


        public void Update( CarteStatus status)
        {
            Status = status;

            AddDomainEvent(new CarteUpdateEvent(this));


        }

        */









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
