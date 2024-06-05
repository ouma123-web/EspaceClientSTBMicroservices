﻿using Twilio.Rest.Api.V2010.Account;

namespace SMSNotification.Services
{
    public interface ISMSService
    {
        MessageResource Send(string mobileNumber, string body);

    }
}
