using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmemIsaac.Blog.Application.Responses
{
    public class BaseResponse
    {
        public string Message { get; }

        public bool Successful { get; protected set; }

        public List<string> ValidationErrors { get; protected set; } = new List<string>();

        public BaseResponse()
        {
            Successful = true;
        }

        public BaseResponse(string message)
        {
            Message = message ?? throw new System.ArgumentNullException(nameof(message));
            Successful = true;
        }

        public BaseResponse(string message, bool successful)
        {
            Message = message ?? throw new System.ArgumentNullException(nameof(message));
            Successful = successful;
        }

        public BaseResponse(IEnumerable<string> errors)
        {
            if (errors is null)
            {
                throw new ArgumentNullException(nameof(errors));
            }
            Successful = false;
            ValidationErrors.AddRange(errors);
        }

        public BaseResponse(ValidationResult result)
        {
            ValidationErrors.AddRange(result.Errors.Select(e => e.ErrorMessage));
            Successful = false;
        }
    }
}
