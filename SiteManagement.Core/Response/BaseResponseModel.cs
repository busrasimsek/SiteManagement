using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SiteManagement.Core.Response
{
    public class BaseResponseModel : BaseResponseModel<object>
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
        private static readonly string BadRequestMessage = "Beklenmedik bir hata oluştu. (BadRequestMessage)";
        public static BaseResponseModel Ok(/*string requestID = null*/)
        {
            var baseResponseModel = new BaseResponseModel();
            baseResponseModel.SetOk();
            return baseResponseModel;
        }

        public static BaseResponseModel<T> Ok<T>(T data, string requestID = null)
        {
            var baseResponseModel = new BaseResponseModel<T>();
            baseResponseModel.SetOk(data, requestID);
            return baseResponseModel;
        }

        public static BaseResponseModel<T> Ok<T>()
        {
            var baseResponseModel = new BaseResponseModel<T>();
            baseResponseModel.SetOk();
            return baseResponseModel;
        }

        public static BaseResponseModel Exception(Exception ex, string requestID = null)
        {
            var exceptionMessages = new List<string>();
            var baseResponseModel = new BaseResponseModel();

            if (!exceptionMessages.Any())
            {
                exceptionMessages = new List<string>()
                {
                    "exceptionMessage: " + ex.Message, "innerException: " + ex.InnerException?.ToString(), "stackTrace: " + ex.StackTrace
                };
            }
            baseResponseModel.SetException(StatusCodes.Status500InternalServerError, exceptionMessages, requestID);
            return baseResponseModel; ;
        }

        public static BaseResponseModel Exception(string message, string requestID = null, int statusCode = StatusCodes.Status500InternalServerError)
        {
            var baseResponseModel = new BaseResponseModel();
            baseResponseModel.SetException(statusCode, message, requestID);
            return baseResponseModel; ;
        }

        public static BaseResponseModel<T> Exception<T>(string message, string requestID = null, int statusCode = StatusCodes.Status500InternalServerError)
        {
            var baseResponseModel = new BaseResponseModel<T>();
            baseResponseModel.SetException(statusCode, message, requestID);
            return baseResponseModel; ;
        }

        public static BaseResponseModel PermissionDenied(string message = "", string requestID = null)
        {
            var baseResponseModel = new BaseResponseModel();
            baseResponseModel.SetException(StatusCodes.Status401Unauthorized, message, requestID);
            return baseResponseModel;
        }

        public static BaseResponseModel BadRequest(string message = "", string requestID = null)
        {
            if (string.IsNullOrEmpty(message))
            {
                message = BadRequestMessage;
            }
            return BadRequest(new List<string> { message }, requestID);
        }

        public static BaseResponseModel<T> BadRequest<T>(string message = "", string requestID = null)
        {
            if (string.IsNullOrEmpty(message))
            {
                message = BadRequestMessage;
            }
            return BadRequest<T>(new List<string> { message }, requestID);
        }
        public static BaseResponseModel BadRequest(List<string> messages = null, string requestID = null)
        {
            var baseResponseModel = new BaseResponseModel();
            baseResponseModel.SetException(StatusCodes.Status400BadRequest, messages, requestID);
            return baseResponseModel;
        }
        public static BaseResponseModel<T> BadRequest<T>(List<string> messages = null, string requestID = null)
        {
            var baseResponseModel = new BaseResponseModel<T>();
            baseResponseModel.SetException(StatusCodes.Status400BadRequest, messages, requestID);
            return baseResponseModel;
        }

    }

    public class BaseResponseModel<T>
    {
        public string RequestID { get; set; }

        public bool IsSuccess { get; set; }

        public List<string> ExceptionMessage { get; set; }

        public int StatusCode { get; set; }

        public T Data { get; set; }


        public BaseResponseModel()
        {
            ExceptionMessage = new List<string>();
        }
        internal void SetOk()
        {
            this.IsSuccess = true;
            this.StatusCode = StatusCodes.Status200OK;
        }
        internal void SetOk(T data, string requestID = null, bool isAsync = false)
        {
            this.Data = data;
            this.RequestID = requestID;
            this.IsSuccess = true;
            this.StatusCode = StatusCodes.Status200OK;
        }
        internal void SetException(int statusCode = StatusCodes.Status500InternalServerError, string message = null, string requestID = null)
        {
            SetException(statusCode, new List<string> { message }, requestID);
        }
        internal void SetException(int statusCode = StatusCodes.Status500InternalServerError, List<string> messages = null, string requestID = null)
        {
            this.StatusCode = statusCode;
            this.ExceptionMessage = messages;
            this.RequestID = requestID;
            this.IsSuccess = false;
        }
    }
}
