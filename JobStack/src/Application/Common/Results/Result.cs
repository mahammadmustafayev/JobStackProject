﻿

namespace JobStack.Application.Common.Results;

public record Result : IResult
{
    public Result(bool success, string message)
           : this(success)
    {
        Message = message;
    }

    public Result(bool success)
    {
        Success = success;
    }

    public bool Success { get; set; }
    public string Message { get; set; }
    public int StatusCode { get; set; }
}
