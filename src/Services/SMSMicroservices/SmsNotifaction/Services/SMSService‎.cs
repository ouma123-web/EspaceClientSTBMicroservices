using SMSNotification.Helpers;
using Twilio.Types;
using Twilio;
using Microsoft.Extensions.Options;
using Twilio.Rest.Api.V2010.Account;

namespace SMSNotification.Services
{
    public class SMSService : ISMSService
    {

        private readonly TwilioSettings _twiliosettings;

        public SMSService(IOptions<TwilioSettings> twiliosettings)
        {
            _twiliosettings = twiliosettings.Value;
        }


        public MessageResource Send(string mobileNumber, string body)
        {
            TwilioClient.Init(_twiliosettings.AccountSID, _twiliosettings.AuthToken);

            // Créer un objet PhoneNumber avec le numéro de téléphone du destinataire
            var messageOptions = new CreateMessageOptions(new PhoneNumber(mobileNumber))
            {
                From = new PhoneNumber(_twiliosettings.TwilioPhoneNumber),
                Body = body
            };

            var message = MessageResource.Create(messageOptions);
            return message;
        }
    }
    }
