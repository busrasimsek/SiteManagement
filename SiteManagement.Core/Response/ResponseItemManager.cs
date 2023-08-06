namespace SiteManagement.Core.Response
{
    public class ResponseItemManager
    {
        public ResponseItemManager()
        {

        }

        public ResponseItem Ok()
        {
            return new ResponseItem { Status = "OK" };
        }
        public ResponseItem<T> Ok<T>(T data)
        {
            return new ResponseItem<T> { Status = "OK", Data = data };
        }
        public ResponseItem<T> Ok<T>(T data, int? count = null)
        {
            return new ResponseItem<T> { Status = "OK", Data = data, Count = count };
        }
        public ResponseItem Ok(ResponseMessage responseMessage)
        {
            return new ResponseItem
            {
                Status = "OK",
                Messages = new List<ResponseMessage>
                {
                    responseMessage
                }
            };
        }

        public ResponseItem Ok<T>(T data, MessageCodesEnum code)
        {
            return new ResponseItem
            {
                Status = "OK",
                Data = data,
                Messages = new List<ResponseMessage>
                {
                    new ResponseMessage { Code = code, Description = code.ToString()}
                }
            };
        }

        public ResponseItem Error(MessageCodesEnum code)
        {
            return new ResponseItem
            {
                Status = "NotOK",
                Messages = new List<ResponseMessage>
                {
                    new ResponseMessage { Code = code}
                }
            };
        }

        public ResponseItem<T> Error<T>(MessageCodesEnum code)
        {
            return new ResponseItem<T>
            {
                Status = "NotOK",
                Messages = new List<ResponseMessage>
                {
                    new ResponseMessage { Code = code, Description = code.ToString()}
                }
            };
        }

        public ResponseItem Error(MessageCodesEnum code, string[] parameters)
        {
            return new ResponseItem
            {
                Status = "NotOK",
                Messages = new List<ResponseMessage>
                {
                    new ResponseMessage { Code = code, Description = string.Format(code.ToString(), parameters) }
                }
            };
        }

        public ResponseItem<T> Error<T>(MessageCodesEnum code, string[] parameters)
        {
            return new ResponseItem<T>
            {
                Status = "NotOK",
                Messages = new List<ResponseMessage>
                {
                    new ResponseMessage { Code = code, Description = string.Format(code.ToString(), parameters) }
                }
            };
        }

        public ResponseItem Error(IList<MessageCodesEnum> codes)
        {
            var responseMessages = codes.Select(x => new ResponseMessage { Code = x, Description = x.ToString() }).ToList();

            return new ResponseItem
            {
                Status = "NotOK",
                Messages = responseMessages
            };
        }

        public ResponseItem<T> Error<T>(IList<MessageCodesEnum> codes)
        {
            var responseMessages = codes.Select(x => new ResponseMessage { Code = x, Description = x.ToString() }).ToList();

            return new ResponseItem<T>
            {
                Status = "NotOK",
                Messages = responseMessages
            };
        }

        public ResponseItem Error(IList<ResponseMessage> responseMessages)
        {
            return new ResponseItem { Status = "NotOK", Messages = responseMessages };
        }

        public ResponseItem<T> Error<T>(IList<ResponseMessage> responseMessages)
        {
            return new ResponseItem<T> { Status = "NotOK", Messages = responseMessages };
        }

        public ResponseItem Error(MessageCodesEnum code, string parameters)
        {
            return new ResponseItem
            {
                Status = "NotOK",
                Messages = new List<ResponseMessage>
                {
                    new ResponseMessage { Code = code, Description = parameters }
                }
            };
        }


    }
}
