﻿using Vega_API.Model.Constants;

namespace Vega_API.Model.Core
{
    public class ApiResponse
    {
        public ApiResponse(string code, string message = null)
        {
            Code = code;
            Message = message != null ? message : GetDefaultMessgae(code);
        }

        public string Code { get; set; }
        public string Message { get; set; }

        protected virtual string GetDefaultMessgae(string statusCode)
        {
            return statusCode switch
            {
                ErrorCodes.BadRequest => ErrorMessages.BadRequest,
                ErrorCodes.Unauthorized => ErrorMessages.Unauthorized,
                ErrorCodes.NotFound => ErrorMessages.NotFound,
                ErrorCodes.Operationfailed => ErrorMessages.Operationfailed,
                ErrorCodes.InternalServerError => ErrorMessages.InternalServerError,
                _ => null
            };
        }
    }
}
