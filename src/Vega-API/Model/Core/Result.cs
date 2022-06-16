﻿namespace Vega_API.Model.Core
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public T Value { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public static Result<T> Success(T value)
        {
            return new Result<T> { IsSuccess = true, Value = value };
        }

        public static Result<T> Fail(string errorCode, string erroMessage = null)
        {
            return new Result<T> { IsSuccess = false, ErrorCode = errorCode, ErrorMessage = erroMessage };
        }
    }
}
