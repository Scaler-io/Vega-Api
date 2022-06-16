using System.Collections.Generic;
using Vega_API.Model.Constants;

namespace Vega_API.Model.Core
{
    public class ApiValidationResponse : ApiResponse
    {
        public List<FieldLevelError> Errors { get; set; }
        public ApiValidationResponse()
            : base(ErrorCodes.UnprocessableEntity)
        {
            Message = GetDefaultMessgae(ErrorCodes.UnprocessableEntity);
        }

        protected override string GetDefaultMessgae(string statusCode)
        {
            return statusCode switch
            {
                ErrorCodes.UnprocessableEntity => "Inputs are invalid",
                _ => null
            };
        }
    }

    public class FieldLevelError
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string Field { get; set; }
    }
}
