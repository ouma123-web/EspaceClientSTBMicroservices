using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSNotification.Services;
using SMSNotification.Dtos;

namespace SMSNotification.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        private readonly ISMSService _smsService;

        // Injection de dépendance du service d'envoi de SMS
        public SMSController(ISMSService smsService)
        {
            _smsService = smsService;
        }

        // Méthode pour recevoir une demande POST pour envoyer un SMS
        [HttpPost("send")]
        public IActionResult Send(SendSMSDto dto)
        {
            // Construire le corps du message SMS en utilisant les données de l'objet dto
            string messageBody = $"Nouvelle transaction bancaire: {dto.TransactionType} de {dto.Amount} EUR.";

            // Appeler le service d'envoi de SMS pour envoyer le message
            var result = _smsService.Send(dto.MobileNumber, messageBody);

            // Vérifier si une erreur s'est produite lors de l'envoi du message
            if (!string.IsNullOrEmpty(result.ErrorMessage))
            {
                // Retourner une réponse BadRequest avec le message d'erreur
                return BadRequest(result.ErrorMessage);
            }

            // Retourner une réponse OK avec un message indiquant que le message a été envoyé avec succès
            return Ok("Message envoyé avec succès.");
        }
    }
}
