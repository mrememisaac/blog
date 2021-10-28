using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmemIsaac.Blog.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> ValidationErrors { get; private set; } = new List<string>();

        public ValidationException(ValidationResult validationResult)
        {
            ValidationErrors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
    }
}
