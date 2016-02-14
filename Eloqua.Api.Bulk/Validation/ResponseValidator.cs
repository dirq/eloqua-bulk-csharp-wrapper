using System.Collections.Generic;
using System.Net;
using Eloqua.Api.Bulk.Exception;
using Eloqua.Api.Bulk.Models.Errors;
using RestSharp;
using RestSharp.Deserializers;

namespace Eloqua.Api.Bulk.Validation
{
    internal class ResponseValidator
    {
        internal static ValidationException GetExceptionFromResponse(IRestResponse response)
        {
            var serializer = new JsonDeserializer();

            switch (response.StatusCode)
            {
                case HttpStatusCode.Conflict:
                    return new ValidationException(
                        response, serializer.Deserialize<List<ObjectValidationError>>(response));

                default:
                    return new ValidationException(response);
            }
        }
    }
}
