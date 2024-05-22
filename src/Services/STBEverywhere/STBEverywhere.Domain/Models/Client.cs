namespace STBEverywhere.Domain.Models
{
    public class Client : Entity<ClientId>
    {

        private readonly List<Compte> _comptes = new();
        public IReadOnlyList<Compte> Comptes => _comptes.AsReadOnly();

        private readonly List<Carte> _cartes = new();
        public IReadOnlyList<Carte> Cartes => _cartes.AsReadOnly();


        private readonly List<CreditClient> _creditclients = new();
        public IReadOnlyList<CreditClient> CreditClients => _creditclients.AsReadOnly();








       


        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Téléphone { get; set; } = int.MaxValue;
        public string Adresse { get; set; } = string.Empty;
        /*
        public static Client Create(ClientId id, string nom, string prenom, string email, int téléphone, string adresse)
         {
         var client = new Client
         {
             Id = id,
             Nom = nom,
             Prenom = prenom,
             Email = email,
             Téléphone = téléphone,
             Adresse = adresse
         };

            client.AddDomainEvent(new ClientCreateEvent(client));
         return client;
         }
        


        public void Update(string nom, string prenom, string email, int téléphone, string adresse)
        {
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Téléphone = téléphone;
            Adresse = adresse;

            AddDomainEvent(new ClientUpdateEvent(this));
        }

        public void Add(OpérationId opérationId,string numcompte,DateTime dateouverture, decimal solde, CompteType type)
        {
            if (string.IsNullOrWhiteSpace(numcompte))
            {
                throw new ArgumentException("Account number cannot be null or whitespace.", nameof(numcompte));
            }

            if (dateouverture == default(DateTime))
            {
                throw new ArgumentOutOfRangeException(nameof(dateouverture), "Date of opening cannot be the default date.");
            }

            if (solde < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(solde), "Balance cannot be negative.");
            }

            if (!Enum.IsDefined(typeof(CompteType), type))
            {
                throw new ArgumentOutOfRangeException(nameof(type), "Invalid account type.");
            }


            var compte = new Compte(Id, opérationId, type, numcompte, solde, dateouverture);
            _comptes.Add(compte);
        }


        public string ConsulterClient()
        {
            return $"Nom: {Nom}, Prénom: {Prenom}, Email: {Email}, Téléphone: {Téléphone}, Adresse: {Adresse}";
        }
        */

        /*CompteId: {CompteId}, CarteId: {CarteId}*/


        

    }
}
