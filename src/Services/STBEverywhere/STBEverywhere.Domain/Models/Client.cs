namespace STBEverywhere.Domain.Models
{
    public class Client : Aggregate<ClientId>
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

        /* public static Client Create(ClientId id, string nom, string prenom, string email)
         {
         var client = new Client
         {
             Id = id,
             Nom = nom,
             Prenom = prenom,
             Email = email
         };

         return client;
         }
        */


        public void Update(string nom, string prenom, string email, int téléphone, string adresse)
        {
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Téléphone = téléphone;
            Adresse = adresse;

            AddDomainEvent(new ClientUpdateEvent(this));
        }


        public string ConsulterClient()
        {
            return $"Nom: {Nom}, Prénom: {Prenom}, Email: {Email}, Téléphone: {Téléphone}, Adresse: {Adresse}";
        }


        /*CompteId: {CompteId}, CarteId: {CarteId}*/




    }
}
