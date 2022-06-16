using Vega_API.Model.Constants;

namespace Vega_API.Model.Core
{
    public class ApiExceptionResponse : ApiResponse
    {
        public string StackTrace { get; set; }
        public ApiExceptionResponse(string errorMessage = null, string stackTrace = null)
            : base(ErrorCodes.InternalServerError, errorMessage)
        {
            StackTrace = stackTrace;
        }
    }
}
