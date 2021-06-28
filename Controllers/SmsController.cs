
using Twilio.AspNet.Common;
using Twilio.AspNet.Core;
using Twilio.TwiML;
using CalculatePi.Models;

namespace CalculatePi.Controllers
{
    public class SmsController : TwilioController
    {
        
        public TwiMLResult Index(SmsRequest incomingMessage)
        {
            int n;
            var messagingResponse = new MessagingResponse();
            if (int.TryParse(incomingMessage.Body, out n))
            {
                FindPi calc = new FindPi(n);
                double pi = calc.EstimatePi(n);
                messagingResponse.Message($"I estimate that pi is {pi}");
            }
            else
            {
                messagingResponse.Message("Please input an integer.");
            }

            return TwiML(messagingResponse);
        }

        
    }
}
