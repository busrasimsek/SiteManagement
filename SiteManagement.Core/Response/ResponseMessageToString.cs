namespace SiteManagement.Core.Response
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
                    message.Add(@"{ Code : " + item.Code + ", Description : " + item.Description + "  }");
                }
            }
            return message;
        }
    }
}
