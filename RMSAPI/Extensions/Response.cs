using Microsoft.AspNetCore.Mvc;
using RMSAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RMSAPI.Extensions
{
    public class Response : IResponse
    {
        public string Message { get; set; }

        public bool IsError { get; set; }

        public string ErrorMessage { get; set; }

    }

    public class SingleResponse<T> : ISingleResponse<T>
    {
        public string Message { get; set; }

        public bool IsError { get; set; }

        public string ErrorMessage { get; set; }
        public int? NumofDays { get; set; }

        public T Model { get; set; }

    }


    public static class ResponseExtensions
    {
        public static IActionResult ToHttpResponse(this IResponse response)
        {
            var status = response.IsError ? HttpStatusCode.InternalServerError : HttpStatusCode.OK;

            return new ObjectResult(response)
            {
                StatusCode = (int)status,
                Value = response
            };
        }

        public static IActionResult ToHttpResponse<T>(this ISingleResponse<T> response)
        {
            var status = HttpStatusCode.OK;

            if (response.IsError)
                status = HttpStatusCode.InternalServerError;
            else if (response.Model == null)
                status = HttpStatusCode.NotFound;
            return new ObjectResult(response)
            {
                StatusCode = (int)status,
                Value = response
            };
        }


        public static IActionResult ToHttpCreatedResponse<T>(this ISingleResponse<T> response)
        {
            var status = HttpStatusCode.Created;

            if (response.IsError)
                status = HttpStatusCode.InternalServerError;
            else if (response.Model == null)
                status = HttpStatusCode.NotFound;

            return new ObjectResult(response)
            {
                StatusCode = (int)status,
                Value = response
            };
        }

    }
}
