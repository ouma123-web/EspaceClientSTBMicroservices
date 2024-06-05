namespace SMSNotification.Dtos
{
    public class SendSMSDto
    {
        public string MobileNumber { get; set; }
        public string TransactionType { get; set; } // Ajoutez une propriété pour le type de transaction
        public decimal Amount { get; set; } // Ajoutez une propriété pour le montant de la transaction

    }
}
