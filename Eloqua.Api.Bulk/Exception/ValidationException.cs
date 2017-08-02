﻿using System.Collections.Generic;
using System.Net;
using Eloqua.Api.Bulk.Models.Errors;
using RestSharp;

namespace Eloqua.Api.Bulk.Exception
{
    public class ValidationException : System.Exception
    {
        public HttpStatusCode StatusCode;
        public string ErrorMessage;
        public string ResponseContent;
        public List<ObjectValidationError> ValidationError;

        public ValidationException(IRestResponse response)
        {
            StatusCode = response.StatusCode;
            ErrorMessage = response.StatusCode.ToString();
            ResponseContent = response.Content;
            ValidationError = new List<ObjectValidationError>();
        }

        public ValidationException(IRestResponse response, List<ObjectValidationError> validationError)
        {
            StatusCode = response.StatusCode;
            ErrorMessage = response.ErrorMessage;
            ResponseContent = response.Content;
            ValidationError = validationError;
        }
    }
}