using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ResponseMessageToString
    {
        public static List<string> ResponseMessageToStr(IList<ResponseMessage> messages)
        {
            List<string> message = new List<string>(); ;
            if (messages != null)
            {
                foreach (ResponseMessage item in messages)
                {
                    message.Add(@"{Description : " + item.Description + "  }");
                }
            }
            return message;
        }
    }
}
