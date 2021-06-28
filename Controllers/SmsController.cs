
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
            bool parsed = int.TryParse(incomingMessage.Body, out n);
            var messagingResponse = new MessagingResponse();
            if (parsed && n >= 0)
            {
                FindPi calc = new FindPi(n);
                double pi = calc.EstimatePi(n);
                messagingResponse.Message($"I estimate that pi is {pi}");
            }
            else
            {
                messagingResponse.Message("Please input a postive integer.");
            }

            return TwiML(messagingResponse);
        }

        
    }
}
