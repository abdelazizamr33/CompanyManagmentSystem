using Company.Route.DAL.Models.Sms;
using Twilio.Rest.Api.V2010.Account;

namespace Company.Route.PL.Helpers
{
    public interface ITwilioService
    {
        public MessageResource SendSms(Sms sms);
    }
}
