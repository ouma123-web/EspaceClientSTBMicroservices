namespace STBEverywhere.Domain.Models
{
    public class Client : Entity<ClientId>
    {

        private readonly List<Compte> _comptes = new();
        public IReadOnlyList<Compte> Comptes => _comptes.AsReadOnly();

        private readonly List<Carte> _cartes = new();
        public IReadOnlyList<Carte> Cartes => _cartes.AsReadOnly();


        private readonly List<ClientCredit> _creditclients = new();
        public IReadOnlyList<ClientCredit> CreditClients => _creditclients.AsReadOnly();
       

        
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Téléphone { get; set; } = int.MaxValue;
        public string Adresse { get; set; } = string.Empty;




        public void Update(string nom, string prenom, string email, int téléphone, string adresse)
        {
            
        }
        

        

    }
}
